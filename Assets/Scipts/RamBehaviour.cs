using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RamBehaviour : SheepBehaviour
{
    bool isRamming = false;
    List<GameObject> rammables;
    
    private void Awake()
    {
        rammables = GameObject.FindGameObjectsWithTag("Rammable").ToList();
    }

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

    private void Update()
    {
        base.Update();

        if (isRamming)
        {
            foreach (GameObject rammable in rammables)
            {
                if (Vector3.Distance(this.gameObject.transform.position, rammable.transform.position) < 2.5f)
                {
                    rammable.SetActive(false);
                }
            }
        }
    }
}
