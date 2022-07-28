using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : Weapon
{
    public override void Start()
    {
        type = "ShortSword";
        base.Start();
    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}