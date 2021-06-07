using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_position : MonoBehaviour
{
    void Awake  ()
    {
        float fScaleHeight = ((float)Screen.height / (float)Screen.width) / ((float)16 / (float)9);
        Vector3 vecPos = GetComponent<RectTransform>().localPosition;
        vecPos.y = vecPos.y * fScaleHeight;
        GetComponent<RectTransform>().localPosition = new Vector3(vecPos.x, vecPos.y, vecPos.z);
    }
}
