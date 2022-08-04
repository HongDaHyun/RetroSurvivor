using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase database;
    public ObjectManager objectManager;
    public List<Item> itemDB = new List<Item>();

    private void Awake()
    {
        database = this;
    }
}
