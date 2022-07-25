using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LanguageManager;

public class LocalizeScript : MonoBehaviour
{
    public string textKey;
    public string[] dropdownKey;

    private void Start()
    {
        LocalizeChanged();
        languageManager.LocalizeChanged += LocalizeChanged;
    }

    private void OnDestroy()
    {
        languageManager.LocalizeChanged -= LocalizeChanged;
    }

    private string Localize(string key)
    {
        int keyIndex = languageManager.langs[0].value.FindIndex(x => x.ToLower() == key.ToLower());
        return languageManager.langs[languageManager.curLangIndex].value[keyIndex];
    }

    private void LocalizeChanged()
    {
        if (GetComponent<Text>() != null)
            GetComponent<Text>().text = Localize(textKey);

        else if(GetComponent<Dropdown>() != null)
        {
            Dropdown dropdown = GetComponent<Dropdown>();
            dropdown.captionText.text = Localize(dropdownKey[dropdown.value]);
            for (int i = 0; i < dropdown.options.Count; i++)
                dropdown.options[i].text = Localize(dropdownKey[i]);
        }
    }
}
