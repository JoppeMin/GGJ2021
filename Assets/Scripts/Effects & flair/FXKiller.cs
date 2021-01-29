using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXKiller : MonoBehaviour {

    public float duration = 3;
 void Start()
    {

        Destroy(gameObject, duration);
        //Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().duration);
    }
}
