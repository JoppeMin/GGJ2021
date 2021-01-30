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
	public List<GameObject> targets = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
		timeSinceLastShot = Time.time;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time - timeSinceLastShot > timeBetweenShots)
		{
			FireAtClosestSheep();
			timeSinceLastShot = Time.time;
		}
    }

	void FireAtClosestSheep()
	{
		if(targets.Count > 0)
		{
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
			if( closestTarget != null)//null check
			{
				transform.LookAt(closestTarget.transform, Vector3.up);
				FireMissile(closestTarget.gameObject);
			}
		}
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
