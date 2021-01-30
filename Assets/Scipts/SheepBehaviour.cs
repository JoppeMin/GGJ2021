using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SheepBehaviour : Mammal
{
    Transform thePlayer;
    Rigidbody rb;
    Animator ani;
<<<<<<< HEAD
    ParticleSystem[] psGroup;
=======
	[SerializeField] GameObject soulParticle;
>>>>>>> cd1be3321ee35c088031576e4fca7b35a9a34295

    [SerializeField]
    float runAwayRadius;
    [SerializeField]
    float movementSpeed;

    bool isRunning = false;
    bool enteredRadius = false;

    Vector3 nonYVector = new Vector3(1, 0, 1);
    Vector3 moveDirection;

    private bool stunned;
    private float timeOfStun;
    private float stunDuration;


    private void OnValidate()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
        ani = this.gameObject.GetComponentInChildren<Animator>();
        psGroup = this.gameObject.GetComponentsInChildren<ParticleSystem>();
    }

	protected override void Start()
    {
		base.Start();
        ani.SetBool("Walk", false);
    }

    void Update()
<<<<<<< HEAD
    {
        if (stunned)
        {
            ani.SetBool("Walk", true);
            if (Time.time - timeOfStun > stunDuration)
            {
                stunned = false;
            }
        }
        else
        {
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1))
            {
                ani.SetBool("Walk", true);
                return;
            }
            else
            {
                if (Vector3.Distance(transform.position, thePlayer.position) < runAwayRadius)
                {
                    ani.SetBool("Walk", true);
                    moveDirection = new Vector3(transform.position.x - thePlayer.position.x, moveDirection.y, transform.position.z - thePlayer.position.z).normalized;

                    if (Input.GetMouseButtonDown(1))
                    {
                        StartCoroutine(SpecialMove());
                    }
                }

                if (!isRunning)
                {
                    StartCoroutine(RunRandomDirection());
                }

                rb.velocity = moveDirection * movementSpeed;
                if (rb.velocity.magnitude > 0.1f)
                {
                    Quaternion r = Quaternion.LookRotation(rb.velocity);
                    transform.rotation = Quaternion.Slerp(transform.rotation, r, Time.deltaTime * 5);
                }
            }
        }
    }
=======
	{
		if (stunned)
		{
			ani.SetBool("Walk", true);
			if(Time.time - timeOfStun > stunDuration)
			{
				stunned = false;
			}
		}
		else
		{
			RaycastHit hit;
			if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1))
			{
				ani.SetBool("Walk", true);
				return;
			}
			else
			{

				if (Vector3.Distance(transform.position, thePlayer.position) < runAwayRadius)
				{
					ani.SetBool("Walk", true);
					moveDirection = new Vector3(transform.position.x - thePlayer.position.x, moveDirection.y, transform.position.z - thePlayer.position.z).normalized;
				}

				if (!isRunning)
				{
					StartCoroutine(RunRandomDirection());
					PlayClip();
				}

				rb.velocity = moveDirection * movementSpeed;
				if (rb.velocity.magnitude > 0.1f)
				{
					Quaternion r = Quaternion.LookRotation(rb.velocity);
					transform.rotation = Quaternion.Slerp(transform.rotation, r, Time.deltaTime * 5);
				}
			}
		}
       
>>>>>>> cd1be3321ee35c088031576e4fca7b35a9a34295

    public virtual IEnumerator SpecialMove()
    {
        PlayParticleGroup(true);
        float storeMovementSpeed = movementSpeed;
        movementSpeed = 13;
        isRunning = true;
        yield return new WaitForSeconds(0.5f);
        movementSpeed = storeMovementSpeed;
        PlayParticleGroup(false);
    }


    IEnumerator RunRandomDirection()
    {
        isRunning = true;
        float timeToRun = Random.Range(0.2f, 0.6f);
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        moveDirection = new Vector3(randomX, rb.velocity.y, randomZ).normalized;
        ani.SetBool("Walk", true);
        yield return new WaitForSeconds(timeToRun);

        float timeToPause = Random.Range(1f, 4f);
        moveDirection = Vector3.zero;
        ani.SetBool("Walk", false);
        yield return new WaitForSeconds(timeToPause);

        isRunning = false;
    }

	public void Stun(float duration)
	{
		stunned = true;
		timeOfStun = Time.time;
		stunDuration = duration;
	}

<<<<<<< HEAD
    private void PlayParticleGroup(bool Play)
    {
        foreach (ParticleSystem ps in psGroup)
        {
            if (Play)
                ps.Play();
            else
                ps.Stop();
        }
    }
=======
	public override void Death()
	{
		Instantiate(soulParticle, transform.position, Quaternion.identity);
		base.Death();
	}
>>>>>>> cd1be3321ee35c088031576e4fca7b35a9a34295

	private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, runAwayRadius);
    }
}
