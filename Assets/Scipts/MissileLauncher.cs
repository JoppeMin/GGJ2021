using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MissileLauncher : MonoBehaviour
{
	[SerializeField] private GameObject homingMissilePrefab;
	[SerializeField] private Transform spawnpoint;

	[SerializeField] private float timeBetweenShots;
	private float timeSinceLastShot;
	List<GameObject> targets = new List<GameObject>();
	public float rotationSpeed;// > 0f and <1f pls
	GameObject crosshair;

	// Start is called before the first frame update
	void Start()
	{
		timeSinceLastShot = Time.time;
		crosshair.SetActive(false);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		FireAtClosestSheep();
	}


	void FireAtClosestSheep()
	{
		if (targets.Count > 0)
		{
			if (!crosshair.activeSelf)
			{
				crosshair.SetActive(true);
			}
			GameObject closestTarget = null;
			float smallestDist = 9999f;
			foreach (GameObject sheep in targets)//which sheep is closest?!
			{
				float dist = Vector3.Distance(sheep.transform.position, gameObject.transform.position);
				if (dist < smallestDist)
				{
					smallestDist = dist;
					closestTarget = sheep;
				}
			}

			RotateTowardsTarget(closestTarget.transform.position);//rotate to target
			crosshair.transform.position = closestTarget.transform.position;

			if (Time.time - timeSinceLastShot > timeBetweenShots)//fire if cooldown allows it
			{
				if (closestTarget != null)//null check
				{
					FireMissile(closestTarget.gameObject);
					timeSinceLastShot = Time.time;
				}
			}
		}
		else
		{
			if(crosshair.activeSelf)
			{
				crosshair.SetActive(false);
			}
		}
	}

	void RotateTowardsTarget(Vector3 targetPos)
	{
		Vector3 lookPos = targetPos - transform.position;
		lookPos.y = 0f;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(lookPos, Vector3.up), rotationSpeed);
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Sheep"))
		{
			targets.Add(other.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Sheep"))
		{
			targets.Remove(other.gameObject);
		}
	}

	private void FireMissile(GameObject target)
	{
		GameObject missile;
		missile = (GameObject)Instantiate(homingMissilePrefab, spawnpoint.position, spawnpoint.transform.rotation);

		missile.GetComponent<HomingMissileV2>().target = target;
	}
}
