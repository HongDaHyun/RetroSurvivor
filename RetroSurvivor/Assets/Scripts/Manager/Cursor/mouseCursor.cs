using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public GameObject selectCursor;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
    }

    public void ChangeMod(string mode)
    {
        switch(mode)
        {
            case "Select":
                Time.timeScale = 0;
                GlobalVariable.isStop = true;
                gameObject.SetActive(false);
                selectCursor.SetActive(true);
                break;
            case "Attack":
                Time.timeScale = 1;
                GlobalVariable.isStop = false;
                gameObject.SetActive(true);
                selectCursor.SetActive(false);
                break;
        }
    }
}
