using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    CSVReader csvReader;
    GameObject chatBox;
    GameObject chatTxtObj;
    TextMeshPro chatTxt;
    protected UIManager uiManager;

    public string npcName;
    List<string> chatList = new List<string>();
    List<string> dialogueList = new List<string>();
    List<string> optionList = new List<string>();

    int talkIndex, optionNum;
    bool isCollision, isTalking;
    public bool isWorking;
    Sprite npcSprite;
    Color defTxtColor;
    public GameObject ownUI;

    public virtual void Awake()
    {
        csvReader = GameObject.Find("CSVReader").GetComponent<CSVReader>();
        chatTxtObj = transform.GetChild(1).gameObject;
        chatTxt = chatTxtObj.GetComponent<TextMeshPro>();
        chatTxt.sortingOrder = 10;
        chatBox = chatTxt.transform.GetChild(0).gameObject;
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        defTxtColor = uiManager.npcOption[0].color;
    }

    private void Start()
    {
        SetChat();
        StartCoroutine(OnChat(0));
    }

    private void Update()
    {
        if(isCollision && !isWorking)
        {
            if(Input.GetKeyDown(KeyCode.F))
                OnTalk();
            if(!isTalking)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    optionNum++;
                    if (optionNum > 2)
                        optionNum = 2;
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    optionNum--;
                    if (optionNum < 0)
                        optionNum = 0;
                }
                OptionUI();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isCollision = false;
    }

    IEnumerator OnChat(int i)
    {
        if (i >= chatList.Count)
            i = 0;
        chatTxt.text = chatList[i];

        float x = chatTxt.preferredWidth;
        x = (x > 3) ? 3 : x + 0.3f;
        chatBox.transform.localScale = new Vector2(x, chatTxt.preferredHeight + 0.3f);

        chatTxtObj.SetActive(true);
        yield return new WaitForSeconds(3f);
        chatTxtObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        StartCoroutine(OnChat(++i));
    }

    private void SetChat()
    {
        for (int i = 0; i < csvReader.npcList.npc.Length; i++)
        {
            if (csvReader.npcList.npc[i].name == npcName)
            {
                switch(csvReader.npcList.npc[i].type)
                {
                    case TextType.Chat:
                        chatList.Add(csvReader.npcList.npc[i].contents);
                        break;
                    case TextType.Dialogue:
                        dialogueList.Add(csvReader.npcList.npc[i].contents);
                        break;
                    case TextType.Option:
                        optionList.Add(csvReader.npcList.npc[i].contents);
                        break;
                }
                if (csvReader.npcList.npc[i].sprite != null)
                    npcSprite = csvReader.npcList.npc[i].sprite;
            }
        }
    }

    private void OnTalk()
    {
        if (talkIndex > 0)
        {
            switch(optionNum)
            {
                case 0:
                    uiManager.npcTxtUI.SetActive(false);
                    ownUI.SetActive(true);
                    isWorking = true;
                    talkIndex = 0;
                    return;
                case 1:
                    isTalking = true;
                    uiManager.npcOptionUI.SetActive(false);
                    if (talkIndex > dialogueList.Count - 2)
                        optionNum = 2;
                    break;
                case 2:
                    uiManager.npcTxtUI.SetActive(false);
                    uiManager.stopUI.SetActive(false);
                    uiManager.npcOptionUI.SetActive(true);
                    Time.timeScale = 1;
                    isTalking = false;
                    optionNum = 0;
                    talkIndex = 0;
                    return;
            }
        }

        uiManager.npcTxtUI.SetActive(true);
        uiManager.stopUI.SetActive(true);
        Time.timeScale = 0;

        uiManager.npcDialogue.text = dialogueList[talkIndex];
        uiManager.npcName.text = npcName;
        uiManager.npcImg.sprite = npcSprite;

        for (int i = 0; i < 3; i++)
            uiManager.npcOption[i].text = optionList[i];

        talkIndex++;
    }

    private void OptionUI()
    {
        for(int i = 0; i < 3; i++)
        {
            if (i == optionNum)
                uiManager.npcOption[i].color = Color.red;
            else
                uiManager.npcOption[i].color = defTxtColor;
        }
    }

    private void OwnUIExit()
    {
        isWorking = false;
        ownUI.SetActive(false);
        uiManager.stopUI.SetActive(false);
        Time.timeScale = 1;
    }
}
