using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class MissileInterceptor : MonoBehaviour
{
	[SerializeField] private GameObject cannon;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<HomingMissileV2>())
		{
			Debug.Log("doei raket");
			if(cannon != null)
			{
				cannon.transform.LookAt(other.transform);
				Debug.Log("pew pew pew");
				// play PFX
			}

			other.GetComponent<HomingMissileV2>().FuckingExplode(); //pew pew
		}
	}
}
