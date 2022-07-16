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
                if (uiManager.ScreenOptionUI.activeSelf)
                {
                    SceneManager.LoadScene(1);
                    uiManager.ScreenOptionUI.SetActive(false);
                }
                else
                    uiManager.ScreenOptionUI.SetActive(true);
                break;
        }
    }
}
