using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public override void Start()
    {
        type = "Slime";
        base.Start();
    }

    private void Stop()
    {
        IsStun = true; //데미지 입을시 isstun이 짧게 풀리는 버그 고치기
    }
    private void NonStop()
    {
        IsStun = false;
    }
}
