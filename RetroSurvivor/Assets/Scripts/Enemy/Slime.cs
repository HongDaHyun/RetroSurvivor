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
        IsStun = true; //������ ������ isstun�� ª�� Ǯ���� ���� ��ġ��
    }
    private void NonStop()
    {
        IsStun = false;
    }
}
