using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AltDialogueLoader : EventBehaviorScript
{
    public PlayerController player;
    public DialogueManager altDialogueManager_1;
    public DialogueManager altDialogueManager_2;

    public override void StartEvent()
    {
        if (player.hasDied)
        {
            altDialogueManager_1.BeginDialogueQueue();
        }
        else
        {
            altDialogueManager_2.BeginDialogueQueue();
        }
    }
}
