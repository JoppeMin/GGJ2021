using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : MonoBehaviour
{
	public List<AudioClip> clips = new List<AudioClip>();
	protected AudioSource audioSource;

	protected virtual void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayClip()
	{
		if(clips.Count > 0)
		{
			audioSource.pitch = Random.Range(0.75f, 1.25f);
			audioSource.loop = false;
			audioSource.PlayOneShot(clips[Random.Range(0, clips.Count)]);
		}
	}

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
