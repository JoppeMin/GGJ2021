using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicContainer : MonoBehaviour
{

	private AudioSource _audioSource;
	private void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = 0.4f;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
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
