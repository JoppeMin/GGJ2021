using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RamBehaviour : SheepBehaviour
{
    bool isRamming = false;

    public override IEnumerator SpecialMove()
    {
        PlayParticleGroup(true);
        float storeMovementSpeed = movementSpeed;
        movementSpeed = 15;
        isRunning = true;
        isRamming = true;

        yield return new WaitForSeconds(0.5f);
        isRamming = false;
        movementSpeed = storeMovementSpeed;
        PlayParticleGroup(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Rammable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
