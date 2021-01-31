using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SheepProcessor : MonoBehaviour
{
    public static SheepProcessor instance;

    private SkinnedMeshRenderer shapekey;
    private Animator anim;

    [SerializeField] Sprite deadSheep;
    TextMeshProUGUI sheepCounter;
    int sheepProcessed = 0;

    [SerializeField] int sheepTarget = 5;
    [HideInInspector] public int amountOfSheepLeft;

    float spoolThickness = 0;
    float spoolTarget = 0;

    void OnValidate()
    {
        shapekey = this.transform.GetComponentInChildren<SkinnedMeshRenderer>();
        anim = GetComponentInChildren<Animator>();
        amountOfSheepLeft = GameObject.FindGameObjectsWithTag("Sheep").Length;
        sheepCounter = GameObject.FindObjectOfType<TextMeshProUGUI>();
    }

    void Start()
    {
        instance = this;
        updateSheepText();
    }

    private void Update()
    {
        if (spoolThickness < spoolTarget)
        {
            spoolThickness += Time.deltaTime * 10;

            shapekey.SetBlendShapeWeight(0, spoolThickness);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            Destroy(other.gameObject);
            sheepProcessed++;
            amountOfSheepLeft--;
            spoolTarget = (100 / sheepTarget) * sheepProcessed;
            anim.SetTrigger("Processing");
            updateSheepText();
        }
    }

    public void updateSheepText()
    {
        sheepCounter.text = $"{sheepProcessed}/{sheepTarget}";
        if ((sheepTarget - sheepProcessed) > amountOfSheepLeft)
        {
            sheepCounter.text = "Game Over \n \n Press 'R' To Restart";
            sheepCounter.alignment = TextAlignmentOptions.Center;
            GameObject.FindObjectOfType<Image>().sprite = deadSheep;
        }
        else if (sheepProcessed >= sheepTarget)
        {
            sheepCounter.text = "Level Complete \n \n Great Job!";
            sheepCounter.alignment = TextAlignmentOptions.Center;
            StartCoroutine(MusicContainer.instance.LoadNextLevel());
        }
    }
}
