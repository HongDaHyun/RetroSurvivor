using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject statUI;
    public GameObject hyperStatUI;

    public Image hpSliderFillImg;
    public Slider hpSlider;
    public Slider expSlider;
    public Text hpText;
    public Text expText;
    public Text levelText;

    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        ControlHp();
        ControlExp();
    }

    private void ControlHp()
    {
        float imsi = (float)player.CurHP / (float)player.maxHP;
        hpSlider.value = Mathf.Lerp(hpSlider.value, imsi, Time.deltaTime * 10);
        hpText.text = $"{player.CurHP}/{player.maxHP}";

        Color color;

        if(imsi > 0.5f)
            ColorUtility.TryParseHtmlString("#36E227", out color);
        else if(imsi > 0.25f)
            ColorUtility.TryParseHtmlString("#E2D827", out color);
        else
            ColorUtility.TryParseHtmlString("#E22B27", out color);
        hpSliderFillImg.color = color;
    }

    private void ControlExp()
    {
        float imsi = (float)player.CurExp / (float)player.MaxExp;
        expSlider.value = Mathf.Lerp(expSlider.value, imsi, Time.deltaTime * 10);
        expText.text = $"{Mathf.Round(imsi * 100)} %";
        levelText.text = $"{player.Level}";
    }
}
