﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public AnimationCurve animationCurve;

    Transform lrTransform;
    public LineRenderer lr;
    Transform ps;

    float widthFactor = 0;
    Vector3 lrPos;

    void Start()
    {
        ps = gameObject.GetComponentInChildren<ParticleSystem>().transform;
        ps.position = new Vector3(1000, 1000, 1000);

        lrTransform = lr.gameObject.transform;
        lr.SetPosition(0, lr.transform.position);
        lr.widthMultiplier = widthFactor;

        lrPos = lrTransform.TransformDirection(Vector3.forward * 1000);
    }

    void Update()
    {
        this.transform.Rotate(new Vector3(0.2f,0,0));

        lr.startColor = new Color(1, widthFactor, widthFactor, widthFactor);
        lr.endColor = new Color(1, widthFactor, widthFactor, widthFactor);
        lr.widthMultiplier = widthFactor/4 + (Mathf.Sin(Time.time * 40) /50);

        lr.SetPosition(0, lr.transform.position);
        lr.SetPosition(1, lrPos);

        widthFactor = animationCurve.Evaluate(Time.time/4);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(lr.transform.position, lr.transform.TransformDirection(Vector3.forward), out hit))
        {
            lrPos = hit.point;
            if (widthFactor >= 1)
            {
                ps.position = hit.point;
                ps.rotation = Quaternion.LookRotation(hit.normal);

                if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Sheep"))
                {
                    hit.collider.GetComponent<Mammal>().Death();
                }
            } 
        }
        else
        {
            lrPos = lr.transform.TransformDirection(Vector3.forward * 1000);
            ps.position = new Vector3(1000, 1000, 1000);
        }
    }
}