using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepProcessor : MonoBehaviour
{

    TextMeshProUGUI sheepCounter;
    int sheepProcessed = 0;
    public int sheepTarget = 5;

    void OnValidate()
    {
        sheepCounter = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }
    void Start()
    {
        updateSheepText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
            sheepProcessed++;
            updateSheepText();
        }
    }

    void updateSheepText()
    {
        sheepCounter.text = $"{sheepProcessed}/{sheepTarget}";
    }
}
