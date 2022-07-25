using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LanguageManager;

public class LocalizeSetting : MonoBehaviour
{
    Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();
    }

    private void Start()
    {
        if (dropdown.options.Count != languageManager.langs.Count)
            SetLangOption();
        dropdown.onValueChanged.AddListener((d) => languageManager.SetLangIndex(dropdown.value));

        LocalizeSettingChanged();
        languageManager.LocalizeSettingChanged += LocalizeSettingChanged;
    }

    private void OnDestroy()
    {
        languageManager.LocalizeSettingChanged -= LocalizeSettingChanged;
    }

    private void SetLangOption()
    {
        List<Dropdown.OptionData> optionDatas = new List<Dropdown.OptionData>();
        for (int i = 0; i < languageManager.langs.Count; i++)
            optionDatas.Add(new Dropdown.OptionData() { text = languageManager.langs[i].langLocalize });
        dropdown.options = optionDatas;
    }

    private void LocalizeSettingChanged()
    {
        dropdown.value = languageManager.curLangIndex;
    }
}
