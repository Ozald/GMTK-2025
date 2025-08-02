using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class G6Spike : EventBehaviorScript
{
    bool eventStarted;
    public Transform endPoint;
    public float speed;

    public override void StartEvent()
    {
        eventStarted = true;
    }

    private void Start()
    {
        eventStarted = false;
    }

    void Update()
    {
        if (eventStarted)
        {    
            if (endPoint.position != transform.position)
            {
                float step = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, endPoint.position, step);
            }
        }
    }
}
