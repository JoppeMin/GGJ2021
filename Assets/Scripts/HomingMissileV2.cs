using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileV2 : HomingMissile
{
	[Header("Forward force values")]
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _force;

	[Header("Rotational force values")]
	[SerializeField] private float _steeringThreshold;//degrees it's pointing away from it's target before adjusting 
	[SerializeField] private float _rotationForce;
	
	[Header("Perlin randomness")]
	[SerializeField] private float _perlinMultiplier;//strength of the noise
	[SerializeField] private float _perlinScale;//how "smooth" the noise will be
	private Vector3 _seed;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start();
		_seed = new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f));
	}


	protected override void Update()
	{
		//helemaal njeaks
	}

	// Update is called once per frame
	protected override void FixedUpdate ()
	{
		HomeInOnTargetV2();
	}

	protected void HomeInOnTargetV2()
	{
		Vector3 targetPos = 
			target.transform.position + GetPerlinValues() 
			* Vector3.Distance(target.transform.position, transform.position) 
			* 0.05f;
		Quaternion targetRot = Quaternion.LookRotation(targetPos - transform.position);

		rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed));
		rb.velocity = Vector3.ClampMagnitude(rb.velocity + transform.forward * _force, _maxSpeed);
	}

	Vector3 GetPerlinValues()
	{
		Vector3 pos = (transform.position + _seed) * _perlinScale;
		Vector3 perlin = new Vector3(
			Mathf.PerlinNoise(pos.y, pos.z) * 2 - 1,
			Mathf.PerlinNoise(pos.x, pos.z) * 2 - 1,
			Mathf.PerlinNoise(pos.x, pos.y) * 2 - 1
			);
		perlin *= _perlinMultiplier;
		return perlin;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Gizmos.DrawSphere(target.transform.position + GetPerlinValues() * Vector3.Distance(target.transform.position, transform.position) * 0.05f, 0.3f);
	}
}
