using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : MonoBehaviour
{

    public virtual void Death()
    {
        if (this.gameObject.CompareTag("Sheep"))
        {
            SheepProcessor.instance.amountOfSheepLeft--;
            SheepProcessor.instance.updateSheepText();
        }
        Destroy(this.gameObject);
    }
}
