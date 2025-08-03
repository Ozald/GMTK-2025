using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G10Duck : EventBehaviorScript
{
    public Transform endPoint;
    public float speed;
    public bool eventStarted = false;
    public GameObject duck;
    public AudioSource audioSource;
    public override void StartEvent()
    {
        audioSource.Play();
        eventStarted = true;
    }
    void Update()
    {
        if (eventStarted)
        {
            
            if (endPoint.position != duck.transform.position)
            {
                float step = speed * Time.deltaTime;

                duck.transform.position = Vector3.MoveTowards(duck.transform.position, endPoint.position, step);
            }
        }
    }


}
