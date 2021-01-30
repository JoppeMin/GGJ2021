using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]//trigger collider for detecting incoming missiles
public class MissileInterceptor : MonoBehaviour
{
	[SerializeField] private GameObject cannon;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<HomingMissileV2>() != null)
		{
			if(cannon != null)
			{
				cannon.transform.LookAt(other.transform);
				// play PFX
			}

			other.GetComponent<HomingMissileV2>().FuckingExplode(); //pew pew
		}
	}
}
