using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SteelSheep : SheepBehaviour
{
	public float freezeTime = 4;
	public float scaleMultiplier;
	private float storeMovementSpeed;
	private Vector3 storeScale;

	public override IEnumerator SpecialMove()
	{
		if (!specialMoveActive)
		{
			
			specialMoveActive = true;
			Stun(9999f);
			rb.isKinematic = true;//schapen duwen hem anders weg
			isRunning = true;
			storeMovementSpeed = movementSpeed;
			storeScale = transform.localScale;
			transform.localScale = transform.localScale * scaleMultiplier;
			movementSpeed = 0f;
			
		}
		else
		{
			specialMoveActive = false;
			isRunning = false;
			movementSpeed = storeMovementSpeed;
			transform.localScale = storeScale;
			rb.isKinematic = false;
			stunDuration = 0f;
		}
		yield break;
	}
}
