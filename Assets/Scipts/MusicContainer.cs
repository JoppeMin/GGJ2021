using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{

	private AudioSource _audioSource;
	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = 0.4f;
	}

	public void PlayMusic()
	{
		if (_audioSource.isPlaying) return;
		_audioSource.Play();
	}

	public void StopMusic()
	{
		_audioSource.Stop();
	}
}
