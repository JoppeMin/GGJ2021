using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
			other.GetComponent<SheepBehaviour>().Death();
            SheepProcessor.instance.amountOfSheepLeft--;
            SheepProcessor.instance.updateSheepText();
        }
    }
}
