using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject statUI;
    public GameObject hyperStatUI;
    public GameObject[] statBtn;
    public GameObject LightUI;

    public Image hpSliderFillImg;
    public Slider hpSlider;
    public Slider expSlider;
    public Text hpText;
    public Text expText;
    public Text levelText;
    public Text[] modifiableStatText;
    public Text[] defStatText;

    public Slots[] equipmentSlots;

    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        ResetStatBtn();
    }

    private void Update()
    {
        ControlHp();
        ControlExp();
        ControlStat();
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

    private void ControlStat()
    {
        modifiableStatText[0].text = $" {player.CurHP}/{player.maxHP}";
        modifiableStatText[1].text = $" {player.damage}";
        modifiableStatText[2].text = $" {player.defense}";
        modifiableStatText[3].text = $" {player.staticDmg}";
        modifiableStatText[4].text = $" {player.staticDef}";
        modifiableStatText[5].text = $" {player.attackSpeed}";
        modifiableStatText[6].text = $" {string.Format("{0:0.#}", player.defSpeed)}";
        modifiableStatText[7].text = $" {player.critical}";
        modifiableStatText[8].text = $" {player.criticalDmg}";
        modifiableStatText[9].text = $" {player.luck}";
        modifiableStatText[10].text = $" {player.aim}";

        defStatText[0].text = " 备泅 x";
        defStatText[1].text = " 备泅 x";
        defStatText[2].text = $" {player.Level}";
        defStatText[3].text = " 备泅 x";
        defStatText[4].text = $" {Mathf.Round(((float)player.CurExp / (float)player.MaxExp) * 100)}%";
        defStatText[5].text = " 备泅 x";
        defStatText[6].text = " 备泅 x";
        defStatText[7].text = $"{player.StatPoint} ";
    }

    public void ResetStatBtn()
    {
        Color gray;
        ColorUtility.TryParseHtmlString("#B5B5B5", out gray);
        for (int i = 0; i < statBtn.Length; i++)
        {
            statBtn[i].GetComponent<Button>().enabled = false;
            statBtn[i].GetComponent<Image>().color = gray;
        }
    }

    public void SetStatBtn()
    {
        if (player.SaveList.Count <= 0)
            return;
        Color green;
        ColorUtility.TryParseHtmlString("#A9E78C", out green);
        for(int i = player.SaveList.Count - 1; i > player.SaveList.Count - 4; i--)
        {
            statBtn[player.SaveList[i]].GetComponent<Button>().enabled = true;
            statBtn[player.SaveList[i]].GetComponent<Image>().color = green;
        }
        statBtn[11].GetComponent<Button>().enabled = true;
        statBtn[11].GetComponent<Image>().color = green;
    }

    public void RedrawEquipmentSlotUI()
    {
        for(int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].RemoveSlot();
        }
        for(int i = 0; i < player.equipments.Count; i++)
        {
            equipmentSlots[i].equipment = player.equipments[i];
            equipmentSlots[i].UpdateSlotUI();
        }
    }

    public void Light()
    {
        if (LightUI.activeSelf)
            return;
        StartCoroutine(Lighting(2));
    }

    IEnumerator Lighting(int time)
    {
        LightUI.SetActive(true);
        Image img = LightUI.GetComponent<Image>();
        for (float i = 0; i <= time; i+=0.5f)
        {
            float f = i / (float)time;
            Color c = img.color;
            c.a = f;
            img.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        if(img.color.a == 1)
        {
            for (float i = time; i >= 0; i-=0.5f)
            {
                float f = i / (float)time;
                Color c = img.color;
                c.a = f;
                img.color = c;
                yield return new WaitForSeconds(0.05f);
            }
            LightUI.SetActive(false);
        }
    }
}
