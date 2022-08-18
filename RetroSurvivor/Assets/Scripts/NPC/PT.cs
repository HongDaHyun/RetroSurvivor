using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT : NPC
{
    public override void Awake()
    {
        base.Awake();
        ownUI = uiManager.ptUI;
    }
}
