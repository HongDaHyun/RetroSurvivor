using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public UIManager uiManager;
    public mouseCursor mouseCursor;
    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        EnterExit("KeyBoard");
    }

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
                            uiManager.stopUI.SetActive(false);
                            mouseCursor.ChangeMod("Attack");
                        }
                        else
                        {
                            uiManager.inventoryUI.SetActive(true);
                            uiManager.stopUI.SetActive(true);
                            mouseCursor.ChangeMod("Select");
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        if (uiManager.statUI.activeSelf)
                        {
                            uiManager.statUI.SetActive(false);
                            uiManager.stopUI.SetActive(false);
                            mouseCursor.ChangeMod("Attack");
                        }
                        else
                        {
                            uiManager.statUI.SetActive(true);
                            uiManager.stopUI.SetActive(true);
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

    public void StatUp(int num)
    {
        switch (num)
        {
            case 0:
                player.maxHP += 5;
                break;
            case 1:
                player.damage += 5;
                break;
            case 2:
                player.defense += 5;
                break;
            case 3:
                player.staticDmg += 1;
                break;
            case 4:
                player.staticDef += 1;
                break;
            case 5:
                player.attackSpeed += 10;
                break;
            case 6:
                player.defSpeed += 0.1f;
                player.CurSpeed = player.defSpeed;
                player.AimSpeed = player.defSpeed / 1.5f;
                break;
            case 7:
                player.critical += 5;
                break;
            case 8:
                player.criticalDmg += 10;
                break;
            case 9:
                player.luck += 1;
                break;
            case 10:
                player.aim += 5;
                break;
            case 11:
                int ranNum = Random.Range(0, 11);
                StatUp(ranNum);
                return;
        }
        player.StatPoint--;
        player.SaveList.RemoveRange(player.SaveList.Count - 3, 3);
        uiManager.ResetStatBtn();
        uiManager.SetStatBtn();
    }

    public void PTUIExit()
    {
        NPC npc = player.npcCollsion.GetComponent<NPC>();
        npc.isWorking = false;
        npc.ownUI.SetActive(false);
        uiManager.stopUI.SetActive(false);
        Time.timeScale = 1;
    }
}
