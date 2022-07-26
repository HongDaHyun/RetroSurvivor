using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public UIManager uiManager;
    public mouseCursor mouseCursor;

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
                        {
                            uiManager.inventoryUI.SetActive(false);
                            mouseCursor.ChangeMod("Attack");
                        }
                        else
                        {
                            uiManager.inventoryUI.SetActive(true);
                            mouseCursor.ChangeMod("Select");
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (uiManager.statUI.activeSelf)
                        {
                            uiManager.statUI.SetActive(false);
                            mouseCursor.ChangeMod("Attack");
                        }
                        else
                        {
                            uiManager.statUI.SetActive(true);
                            mouseCursor.ChangeMod("Select");
                        }
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
