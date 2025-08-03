using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class G12clicking : MonoBehaviour
{
    public float totalPoints;
    public float pointsPerClick = 1;
    public float clickPerSec = 0;
    public TextMeshProUGUI text;
    public AudioSource audioSource;

    private void Update()
    {
        text.text = "Total points: " + totalPoints;
        
    }
    private void OnMouseDown()
    {
        audioSource.Play();
        totalPoints += pointsPerClick;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            totalPoints += clickPerSec;
        }
    }
}
