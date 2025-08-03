using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class G13ShowQueue : EventBehaviorScript
{
    public TextMeshProUGUI queueTime;
    public DialogueManager nextDialogue;
    public GameObject loadingIcon;

    public override void StartEvent()
    {
        queueTime.enabled = true;
        loadingIcon.SetActive(false);
        nextDialogue.BeginDialogueQueue();

    }
}
