using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableExit : EventBehaviorScript
{
    public PlayerController player;
    public override void StartEvent()
    {
        player.canExit = true;
    }
}
