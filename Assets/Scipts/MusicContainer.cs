using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicContainer : MonoBehaviour
{
    public static MusicContainer instance;

	private AudioSource _audioSource;
	public AudioClip winsound;
	private float defaultvolume = 0.4f;
	private void Awake()
	{
        instance = this;
		DontDestroyOnLoad(transform.gameObject);
		_audioSource = GetComponent<AudioSource>();
		_audioSource.volume = defaultvolume;
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

    public IEnumerator LoadNextLevel()
    {
		_audioSource.volume = 0.15f;
		_audioSource.PlayOneShot(winsound, 2.5f);
		yield return new WaitForSeconds(5);
		_audioSource.volume = defaultvolume;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
