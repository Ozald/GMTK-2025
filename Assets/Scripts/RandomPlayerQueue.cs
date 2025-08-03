using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomPlayerQueue : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int currentUsersOnline;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        StartCoroutine(RandomizePlayerCount());
    }

    void Update()
    {
        text.text = "Waiting in queue (" + currentUsersOnline + ")\r\nEstimate Queue Time: 4 hours";
    }

    IEnumerator RandomizePlayerCount()
    {
        while (true)
        {
            currentUsersOnline = 2387 + Random.Range(-50, 51);
            yield return new WaitForSeconds(2f);
        }
    }
}
