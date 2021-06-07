using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    Text t;

    void Awake()
    {
        t = GetComponent<Text>();
        StartCoroutine(FadeTextToFullAlpha());
    }

    IEnumerator FadeTextToFullAlpha() // ���İ� 0���� 1�� ��ȯ
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
        while (t.color.a < 1.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    IEnumerator FadeTextToZero()  // ���İ� 1���� 0���� ��ȯ
    {
        t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
        while (t.color.a > 0.0f)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / 1.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }

}
