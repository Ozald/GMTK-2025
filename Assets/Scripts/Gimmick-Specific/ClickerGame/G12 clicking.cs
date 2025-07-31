using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class G12clicking : MonoBehaviour
{
    public float totalPoints;
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = "Total points: " + totalPoints;
    }
    private void OnMouseDown()
    {
        totalPoints++;
    }
}
