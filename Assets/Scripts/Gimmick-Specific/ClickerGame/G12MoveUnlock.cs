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
    public AudioSource audioSource;
    public TextMeshProUGUI connectedText;
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
        if (clickerScript.totalPoints >= purchaseAmount)
        {
            connectedText.text = "";
            text.text = "";
            audioSource.Play();
            clickerScript.totalPoints -= purchaseAmount;
            pc.canMove = true;
            Destroy(gameObject);
        }
    }
}
