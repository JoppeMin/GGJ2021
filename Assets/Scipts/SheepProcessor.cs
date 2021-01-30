using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SheepProcessor : MonoBehaviour
{

    TextMeshProUGUI sheepCounter;
    int sheepProcessed = 0;
    [SerializeField]
    int sheepTarget = 5;
    [HideInInspector]
    public int amountOfSheepLeft;

    void OnValidate()
    {
        amountOfSheepLeft = GameObject.FindGameObjectsWithTag("Sheep").Length;
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
            amountOfSheepLeft--;
            updateSheepText();
        }
    }

    public void updateSheepText()
    {
        sheepCounter.text = $"{sheepProcessed}/{sheepTarget}    {amountOfSheepLeft}";
        if ((sheepTarget - sheepProcessed) > amountOfSheepLeft)
        {
            sheepCounter.text = "Game Over";
        }
    }
}
