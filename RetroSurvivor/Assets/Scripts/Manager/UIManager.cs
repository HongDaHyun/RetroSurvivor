using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject screenOptionUI;
    public GameObject inventoryUI;

    public Image hpSliderFillImg;
    public Slider hpSlider;
    public Text hpText;

    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        ControlHp();
    }

    private void ControlHp()
    {
        float imsi = (float)player.CurHP / (float)player.MaxHP;
        hpSlider.value = Mathf.Lerp(hpSlider.value, imsi, Time.deltaTime * 10);
        hpText.text = $"{player.CurHP}/{player.MaxHP}";

        Color color;

        if(imsi > 0.5f)
            ColorUtility.TryParseHtmlString("#36E227", out color);
        else if(imsi > 0.25f)
            ColorUtility.TryParseHtmlString("#E2D827", out color);
        else
            ColorUtility.TryParseHtmlString("#E22B27", out color);
        hpSliderFillImg.color = color;
    }
}
