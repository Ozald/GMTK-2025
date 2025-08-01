using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class G12MoveUnlock : MonoBehaviour
{
    public float purchaseAmount;
    public G12clicking clickerScript;
    public PlayerController pc;
    public TextMeshProUGUI text;
    void Start()
    {

    }

    private void Update()
    {
        text.text = "Cost: " + purchaseAmount;
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (clickerScript.totalPoints > purchaseAmount)
        {
            clickerScript.totalPoints -= purchaseAmount;
            pc.canMove = true;
            Destroy(gameObject);
        }
    }
}
