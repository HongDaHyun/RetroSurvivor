using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed;
    public float alphaSpeed;

    TextMeshPro text;
    Color alpha;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        StartCoroutine(Active());
    }

    private void OnEnable()
    {
        Color color;
        ColorUtility.TryParseHtmlString("#E5E3E3", out color);
        text.color = color;
        alpha = text.color;
    }

    IEnumerator Active()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    public void DmgTxt(int x)
    {
        text.text = x.ToString();
    }
}
