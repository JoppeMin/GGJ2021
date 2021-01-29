using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : SheepTypeList
{
	public Collider col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<SheepTypeList>())
		{
			SheepTypeList otherList = other.GetComponent<SheepTypeList>();
			if (Basic && otherList.Basic)
			{
				//kill schaap
			}
			else if (LightWeight && otherList.LightWeight)
			{
				//schaap dood
			}
			else if (HeavyWeight && otherList.HeavyWeight)
			{
				//rip
			}
			else if(LongLegs && otherList.LongLegs)
			{
				//dede
			}
			else if(Flying && otherList.Flying)
			{

			}
			else if(Reflecting && otherList.Reflecting)
			{
				//omegarip
			}
		}
		
	}
}
