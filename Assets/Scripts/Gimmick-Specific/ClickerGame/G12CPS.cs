using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class G12CPS : MonoBehaviour
{
    // Start is called before the first frame update

    public float purchaseAmount;
    public G12clicking clickerScript;
    public TextMeshProUGUI text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Cost: " + purchaseAmount;
    }

    private void OnMouseDown()
    {
        if (clickerScript.totalPoints > purchaseAmount)
        {
            clickerScript.totalPoints -= purchaseAmount;
            purchaseAmount += 20;
            clickerScript.clickPerSec++;
        }
    }
}
