using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class PlayerController : Mammal
{
	Rigidbody rb;
    Animator anim;
	NavMeshAgent playerAgent;
	[SerializeField] private LayerMask hittableLayers;

	void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
		rb = gameObject.GetComponent<Rigidbody>();
		playerAgent = gameObject.GetComponent<NavMeshAgent>();
	}

    void Update()
    {
		Movement();
	}

	void Movement()
	{
		if (Input.GetMouseButton(0))
		{
            
			MouseToWorldRaycast raycast = RaycastScreenToWorld();
			if (raycast.raycastHasHit)
			{
				playerAgent.SetDestination(raycast.hitData.point);
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
            anim.SetBool("Walk", false);
            playerAgent.ResetPath();
		}
	}

	private MouseToWorldRaycast RaycastScreenToWorld()//probably more complicated than necessary
	{
		MouseToWorldRaycast rayHit;
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			//create a ray cast and set it to the mouses cursor position in game
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out rayHit.hitData, 100.0f, hittableLayers))
			{
				rayHit.raycastHasHit = true;
                anim.SetBool("Walk", true);
            }
			else
			{
				rayHit.raycastHasHit = false;
			}
		}
		else
		{
			rayHit.raycastHasHit = false;
			rayHit.hitData = new RaycastHit();
		}
		return rayHit;
	}

	struct MouseToWorldRaycast
	{
		public bool raycastHasHit;
		public RaycastHit hitData;
	}
}
