using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct DialogueEvent
{
    public string text;
    public float delay;
    public float duration;
    public EventBehaviorScript scriptToRunAtEnd;
}

public class DialogueManager : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshProUGUI subtitles;
    public bool playOnStart = true;
    public float dialogueDelay = 0f;
    public List<DialogueEvent> dialogueQueue = new List<DialogueEvent>();

    // Start is called before the first frame update
    void Start()
    {
        if (playOnStart)
        {
            StartCoroutine("PlayDialogueQueue");
        }
    }

    public void BeginDialogueQueue()
    {
        StartCoroutine("PlayDialogueQueue");
    }

    private IEnumerator PlayDialogueQueue()
    {
        yield return new WaitForSeconds(dialogueDelay);

        if (audioSource != null)
            audioSource.Play();

        foreach (DialogueEvent dialogueEvent in dialogueQueue)
        {
            subtitles.text = "";
            yield return new WaitForSeconds(dialogueEvent.delay);
            subtitles.text = dialogueEvent.text;
            yield return new WaitForSeconds(dialogueEvent.duration);
            if (dialogueEvent.scriptToRunAtEnd != null)
            {
                dialogueEvent.scriptToRunAtEnd.StartEvent();
            }
        }

        subtitles.text = "";
    }
}
