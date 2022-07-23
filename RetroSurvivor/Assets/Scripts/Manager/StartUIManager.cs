using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour
{
    public GameObject screenOptionUI;
    public void Btn(string name)
    {
        switch(name)
        {
            case "ScreenOption":
                if (screenOptionUI.activeSelf)
                {
                    SceneManager.LoadScene(1);
                    GlobalVariable.isStart = true;
                    screenOptionUI.SetActive(false);
                }
                else
                    screenOptionUI.SetActive(true);
                break;
        }
    }
}
