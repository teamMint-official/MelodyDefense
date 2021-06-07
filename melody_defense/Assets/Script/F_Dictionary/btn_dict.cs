using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_dict : MonoBehaviour
{
    sc_dictionary d;


    void Awake()
    {
        d = GameObject.Find("camera").GetComponent<sc_dictionary>();
    }

    public void clickNext() {
        d.next_ch();
    }

    public void clickPre() {
        d.pre_ch();
    }

    public void clickSelect() {
        d.sel_ch();
    }
}
