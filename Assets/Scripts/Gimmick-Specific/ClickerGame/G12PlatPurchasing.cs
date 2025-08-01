using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G12PlatPurchasing : MonoBehaviour
{
    public float purchaseAmount;
    public G12clicking clickerScript;
    public bool platformBought = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (clickerScript.totalPoints > purchaseAmount)
        {
            clickerScript.totalPoints -= purchaseAmount;
            platformBought = true;
            Destroy(gameObject);
        }
    }
}
