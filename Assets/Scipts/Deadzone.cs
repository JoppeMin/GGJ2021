using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    SheepProcessor processor;

    private void OnValidate()
    {
        processor = GameObject.FindObjectOfType<SheepProcessor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
            processor.amountOfSheepLeft--;
            processor.updateSheepText();
        }
    }
}
