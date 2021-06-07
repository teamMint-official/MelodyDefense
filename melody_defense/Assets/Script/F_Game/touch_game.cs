using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touch_game : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]short posX;
    [SerializeField]Image view_char;

    sc_playerCtl pMgr;
    DataController mgr;

    void Awake() {
        pMgr = GameObject.Find("playerCtl").GetComponent<sc_playerCtl>();
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        view_char.sprite = mgr._idle;
    }


    public void OnPointerDown(PointerEventData data)
    {
        view_char.sprite = mgr._shoot;
        pMgr._requireCheck(posX);
    }

    public void OnPointerUp(PointerEventData data)
    {
        view_char.sprite = mgr._idle;
    }
}
