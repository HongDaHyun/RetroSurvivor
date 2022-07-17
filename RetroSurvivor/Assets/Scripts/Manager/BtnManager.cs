using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public UIManager uiManager;

    public void EnterExit(string name)
    {
        switch(name)
        {
            case "ScreenOption":
                if (uiManager.screenOptionUI.activeSelf)
                {
                    SceneManager.LoadScene(1);
                    GlobalVariable.isStart = true;
                    uiManager.screenOptionUI.SetActive(false);
                }
                else
                    uiManager.screenOptionUI.SetActive(true);
                break;
            case "Inventory":
                if(Input.GetKeyDown(KeyCode.I) && GlobalVariable.isStart)
                {
                    if(uiManager.inventoryUI.activeSelf)
                        uiManager.inventoryUI.SetActive(false);
                    else
                        uiManager.inventoryUI.SetActive(true);
                }
                break;
        }
    }

    private void Update()
    {
        EnterExit("Inventory");
    }
}
