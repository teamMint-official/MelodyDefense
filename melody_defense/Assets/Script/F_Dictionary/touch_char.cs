using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class touch_char : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    sc_dictionary d;

    // Start is called before the first frame update
    void Awake()
    {
        d = GameObject.Find("camera").GetComponent<sc_dictionary>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        d.touchDown();
    }

    public void OnPointerUp(PointerEventData data)
    {
        d.touchUp();
    }
}
