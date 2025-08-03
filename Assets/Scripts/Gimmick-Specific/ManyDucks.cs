using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyDucks : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

        if (Random.Range(1,50) == 1)
        {
            audioSource.Play();
        }
    }
}
