using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public GameObject player;
	public GameObject rocket1, rocket2;
	public GameObject sheep1, sheep2, sheep3;
	private Vector3 startpos1, startpos2;
	public MusicContainer container;

	private float bouncespeed = 1f;
	private float bounceheight = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        sheep1.GetComponent<Animator>().SetBool("Walk", true);
		sheep1.GetComponent<Animator>().speed = 0.95f;
        sheep2.GetComponent<Animator>().SetBool("Walk", true);
        sheep3.GetComponent<Animator>().SetBool("Walk", true);
		sheep3.GetComponent<Animator>().speed = 1.05f;
		player.GetComponent<Animator>().SetBool("Walk", true);

		startpos1 = rocket1.transform.position;
		startpos2 = rocket2.transform.position;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		rocket1.transform.Rotate(0f, 0f, 6f);
		rocket2.transform.Rotate(0f, 0f, -6f);
		rocket1.transform.position = startpos1 + new Vector3(Mathf.Sin(Time.time * bouncespeed) * bounceheight, Mathf.Sin(Time.time * (bouncespeed)) * bounceheight, 0.0f);
		rocket2.transform.position = startpos2 + new Vector3(Mathf.Sin(Time.time * (bouncespeed + 0.1f)) * bounceheight, 0.0f, Mathf.Sin(Time.time * (bouncespeed + 0.1f)) * bounceheight);
	}

	public void StartGame()
	{
		container.PlayMusic();
		SceneManager.LoadScene("Level 1");
	}
}
