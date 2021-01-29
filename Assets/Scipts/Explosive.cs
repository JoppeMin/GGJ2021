using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

   protected float lifetime;
    private float aliveTime;
	public GameObject explosionFX;
    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	protected virtual void Update () {
        //LifeSpan();
	}

    public virtual void LifeSpan()
    {
        aliveTime += Time.deltaTime;
        if (aliveTime >= lifetime)
            FuckingExplode();
    }

    public virtual void FuckingExplode()
    {
        Instantiate(explosionFX, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
