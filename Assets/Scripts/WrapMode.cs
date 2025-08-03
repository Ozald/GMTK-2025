using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WrapMode : MonoBehaviour
{
    void Start()
    {
        GetComponent<PlayableDirector>().extrapolationMode = DirectorWrapMode.Hold;
    }
}
