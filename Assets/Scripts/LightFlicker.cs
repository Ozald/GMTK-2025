using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light;

    void Start()
    {
        StartCoroutine("StartLightFlicker");
    }

    IEnumerator StartLightFlicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            for (int i = 0; i < 3; i++)
            {
                light.intensity = 0.3f;
                yield return new WaitForSeconds(0.05f);
                light.intensity = 0.6f;
                yield return new WaitForSeconds(0.05f);
            }
            
        }
    }
}
