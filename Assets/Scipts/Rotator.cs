using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float rotationSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
		transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
    }
}
