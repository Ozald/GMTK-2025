using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G8WallOpen : EventBehaviorScript
{
    public Transform wall;
    public Transform endPoint;
    public float speed = 5f;

    private bool eventStarted;
    public override void StartEvent()
    {
        eventStarted = true;
    }

    void Update()
    {
        if (eventStarted)
        {
            if (wall.position != endPoint.position)
            {
                float step = speed * Time.deltaTime;

                wall.position = Vector3.MoveTowards(wall.position, endPoint.position, step);
            }
            else
            {
                eventStarted = false;
            }
        }
    }
}
