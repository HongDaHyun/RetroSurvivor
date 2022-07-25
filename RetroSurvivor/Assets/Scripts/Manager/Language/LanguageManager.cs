using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Lang
{
    public string lang, langLocalize;
    public List<string> value = new List<string>();
}

public class LanguageManager : MonoBehaviour
{
    const string langURL = "https://docs.google.com/spreadsheets/d/1JcWc6y-eGRTggmgp6UssHJh7Uz0U0-Xc5fKk6Uwsstc/export?format=tsv";
    public event System.Action LocalizeSettingChanged = () => { };
    public event System.Action LocalizeChanged = () => { };
    public int curLangIndex;
    public List<Lang> langs;

    #region 언어
    public static LanguageManager languageManager;
    private void Awake()
    {
        if (null == languageManager)
        {
            languageManager = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
        InitLang();
    }
    #endregion

    private void InitLang()
    {
        int langIndex = PlayerPrefs.GetInt("LangIndex", -1);
        int systemIndex = langs.FindIndex(x => x.lang.ToLower() == Application.systemLanguage.ToString().ToLower());
        if (systemIndex == -1)
            systemIndex = 0;
        int index = langIndex == -1 ? systemIndex : langIndex;

        SetLangIndex(index);
    }

    public void SetLangIndex(int index)
    {
        curLangIndex = index;
        PlayerPrefs.SetInt("LangIndex", curLangIndex);
        LocalizeSettingChanged();
        LocalizeChanged();
    }

    [ContextMenu("언어 가져오기")]
    private void GetLang()
    {
        StartCoroutine(GetLangCo());
    }

    IEnumerator GetLangCo()
    {
        UnityWebRequest www = UnityWebRequest.Get(langURL);
        yield return www.SendWebRequest();
        SetLangList(www.downloadHandler.text);
    }

    private void SetLangList(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;
        string[,] sentence = new string[rowSize, columnSize];

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');
            for (int j = 0; j < columnSize; j++)
                sentence[i, j] = column[j];
        }

        //클래스 리스트
        langs = new List<Lang>();
        for(int i = 0; i < columnSize; i++)
        {
            Lang lang = new Lang();
            lang.lang = sentence[0, i];
            lang.langLocalize = sentence[1, i];

            for (int j = 2; j < rowSize; j++)
                lang.value.Add(sentence[j, i]);
            langs.Add(lang);
        }
    }
}
