using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public UIManager uiManager;

    public void EnterExit(string name)
    {
        if (GlobalVariable.isStart)
        {
            switch (name)
            {
                case "KeyBoard":
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        if (uiManager.inventoryUI.activeSelf)
                            uiManager.inventoryUI.SetActive(false);
                        else
                            uiManager.inventoryUI.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (uiManager.statUI.activeSelf)
                            uiManager.statUI.SetActive(false);
                        else
                            uiManager.statUI.SetActive(true);
                    }
                    break;
                case "HyperStat":
                    if (uiManager.hyperStatUI.activeSelf)
                        uiManager.hyperStatUI.SetActive(false);
                    else
                        uiManager.hyperStatUI.SetActive(true);
                    break;
            }
        }
    }

    private void Update()
    {
        EnterExit("KeyBoard");
    }
}
