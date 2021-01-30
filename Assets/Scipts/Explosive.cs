﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    [SerializeField] protected float lifetime;
    private float aliveTime;
	public GameObject explosionFX;
	public bool explosionHasForce;
	public float explosionRadius;
	public float explosionForce;
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	protected virtual void Update () {
        LifeSpan();
	}

    public virtual void LifeSpan()
    {
        aliveTime += Time.deltaTime;
        if (aliveTime >= lifetime)
            FuckingExplode();
    }

    public virtual void FuckingExplode()
    {
		if (explosionHasForce)
		{
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
			foreach (Collider hit in colliders)
			{
				if (hit.gameObject.GetComponent<SheepBehaviour>() != null)
				{
					hit.gameObject.GetComponent<SheepBehaviour>().Stun(1f);
				}
				Rigidbody rb = hit.GetComponent<Rigidbody>();

				if (rb != null)
					rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 3.0F, ForceMode.Impulse);
			}
		}
	

		Instantiate(explosionFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
