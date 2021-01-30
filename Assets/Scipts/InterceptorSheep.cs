using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MissileInterceptor))]
public class InterceptorSheep : SheepBehaviour
{
	MissileInterceptor interceptor;
	public float activeDuration = 3f;
	protected override void Start()
	{
		base.Start();
		interceptor = GetComponent<MissileInterceptor>();
	}

	public override IEnumerator SpecialMove()
	{
		if (!specialMoveActive)
		{
			specialMoveActive = true;
			interceptor.isEnabled = true;
			yield return new WaitForSeconds(activeDuration);
			interceptor.isEnabled = false;
			specialMoveActive = false;
		}
		yield break;
	}
}
