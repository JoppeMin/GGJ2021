using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
            SheepProcessor.instance.amountOfSheepLeft--;
            SheepProcessor.instance.updateSheepText();
        }
    }
}
