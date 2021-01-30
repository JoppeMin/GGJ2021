using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]//trigger collider for detecting incoming missiles
public class MissileInterceptor : MonoBehaviour
{
	[SerializeField] private GameObject cannon;
	public bool isEnabled;

	private void FixedUpdate()
	{
		if (isEnabled)
		{
			cannon.transform.Rotate(0f, 10f, 0f);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (isEnabled)
		{
			if (other.gameObject.GetComponent<HomingMissileV2>() != null)
			{
				if (cannon != null)
				{
					cannon.transform.LookAt(other.transform);
					// play PFX
				}
				//draw laser
				other.GetComponent<HomingMissileV2>().FuckingExplode(); //pew pew
			}
		}
	}
}
