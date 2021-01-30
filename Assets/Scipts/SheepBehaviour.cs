using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SheepBehaviour : Mammal
{
    protected Transform thePlayer;
    protected Rigidbody rb;
    protected Animator ani;
	protected bool specialMoveActive;
    ParticleSystem[] psGroup;
	[SerializeField] GameObject soulParticle;
    [SerializeField] protected float runAwayRadius;
    [SerializeField] protected float movementSpeed;

    protected bool isRunning = false;
    protected bool enteredRadius = false;

    Vector3 nonYVector = new Vector3(1, 0, 1);
    protected Vector3 moveDirection;

    protected bool stunned;
    protected float timeOfStun;
    protected float stunDuration;


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

	protected virtual void Update()
	{
		if (stunned)
		{
			ani.SetBool("Walk", false);
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
	}

    public virtual IEnumerator SpecialMove()
    {
		if (!specialMoveActive)
		{
			specialMoveActive = true;
			PlayParticleGroup(true);
			float storeMovementSpeed = movementSpeed;
			movementSpeed = 13;
			isRunning = true;
			yield return new WaitForSeconds(0.5f);
			specialMoveActive = false;
			movementSpeed = storeMovementSpeed;
			PlayParticleGroup(false);
		}
		else
		{
			yield break;
		}
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


    protected void PlayParticleGroup(bool Play)
    {
        foreach (ParticleSystem ps in psGroup)
        {
            if (Play)
                ps.Play();
            else
                ps.Stop();
        }
    }

	public override void Death()
	{
		Instantiate(soulParticle, transform.position, Quaternion.identity);
		base.Death();
	}

    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, runAwayRadius);
    }
}
