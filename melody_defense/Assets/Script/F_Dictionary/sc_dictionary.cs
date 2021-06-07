using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_dictionary : MonoBehaviour
{
    short ch_val = 0;
    short max = 1, min = 0;

    bool is_tou_ch = false;

    public Sprite[] ch_idle;
    public Sprite[] ch_shoot;

    public Image view_ch;

    DataController mgr;

    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        ch_val = mgr.getselchar();
        view_ch.sprite = ch_idle[ch_val];
    }

    void Update()
    {
        if (ch_val > max) ch_val = min;
        else if (ch_val < min) ch_val = max;

        if (!is_tou_ch) view_ch.sprite = ch_idle[ch_val];//��ġ ���� ��
        else view_ch.sprite = ch_shoot[ch_val];//�̹����� ��ġ�� ��

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sel_ch();
            SceneManager.LoadSceneAsync("_Lobby");
        }

    }

    public void next_ch()
    {//���� ĳ����
        ch_val++;
    }
    public void pre_ch()
    {//���� ĳ����
        ch_val--;
    }

    public void sel_ch() {//ĳ���� ����
        mgr.set_selchar(ch_val);
    }

    public void touchDown()
    {
        is_tou_ch = true;
    }

    public void touchUp()
    {
        is_tou_ch = false;
    }



}
