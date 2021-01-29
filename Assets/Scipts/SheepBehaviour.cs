using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SheepBehaviour : MonoBehaviour
{
    Transform thePlayer;
    Rigidbody rb;

    [SerializeField]
    float runAwayRadius;
    [SerializeField]
    float movementSpeed;

    bool isRunning = false;
    bool enteredRadius = false;

    Vector3 nonYVector = new Vector3(1, 0, 1);
    Vector3 moveDirection;
    Vector3 gravity = Vector3.down * 6f;


    private void OnValidate()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, thePlayer.position) < runAwayRadius)
        {
            moveDirection = Vector3.Scale(nonYVector, (((transform.position - thePlayer.position).normalized) * movementSpeed));
        }

        if (!isRunning)
        {
            StartCoroutine(RunRandomDirection());
        }

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            moveDirection = gravity;
        }

        rb.velocity = moveDirection;
        if (rb.velocity.magnitude > 0.1f)
        {
            Quaternion r = Quaternion.LookRotation(rb.velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, r, Time.deltaTime * 5);
        }
    }

    IEnumerator RunRandomDirection()
    {
        isRunning = true;
        float timeToRun = Random.Range(0.5f, 1.5f);
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);

        moveDirection = Vector3.Scale(nonYVector, (new Vector3(randomX, rb.velocity.y, randomZ) * movementSpeed));
        yield return new WaitForSeconds(timeToRun);

        float timeToPause = Random.Range(1f, 4f);
        moveDirection = Vector3.zero;
        yield return new WaitForSeconds(timeToPause);

        isRunning = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, runAwayRadius);
    }
}
