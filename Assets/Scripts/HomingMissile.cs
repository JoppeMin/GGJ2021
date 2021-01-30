using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Explosive
{
    public GameObject target;
    public float rotationSpeed;
    public float velocity;
    protected Rigidbody rb;
    private Quaternion rotation;
    [SerializeField] private GameObject smokeTrail;
    

    // Use this for initialization
    protected override void Start () {
		base.Start();
        rb = gameObject.GetComponent<Rigidbody>();
        if (target == null)
            target = GameObject.Find("Player");
	}

	// Update is called once per frame
	protected override void Update ()
	{
        base.Update();
	}

	protected virtual void FixedUpdate()
	{
		HomeToTarget();
	}

	protected void HomeToTarget()
	{
		Debug.Log("homing V1");
		rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		//transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
		rb.velocity = gameObject.transform.forward * velocity;
		rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed));
	}

    private void OnCollisionEnter(Collision collision)
    {
        FuckingExplode();
    }

    public override void FuckingExplode()
    {
		smokeTrail.gameObject.AddComponent<FXKiller>().duration = 4f;
		smokeTrail.transform.SetParent(null);
       
		base.FuckingExplode();
    }
}
