using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_playerCtl : MonoBehaviour
{
    sbyte life;
    int score;
    timingMgr t_mgr;
    noteMgr n_mgr;
    public Text sc_val;

    public Image[] hp;
    public Sprite[] heart;

    void Awake()
    {
        life = 3;
        score = 0;
        t_mgr = FindObjectOfType<timingMgr>();
        n_mgr = GameObject.Find("_noteMgr").GetComponent<noteMgr>();

        for (int i = 0; i < 3; i++) {
            hp[i].sprite = heart[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        sc_val.GetComponent<Text>().text = score.ToString();

        if (life < 1) {//체력이 0이 되면 실패
            n_mgr._Fn_pause();
            StartCoroutine(n_mgr.gamefail());
        }
    }

    public void _requireCheck(short a) {
        if (!n_mgr.getPause())
        {
            string c = t_mgr.checkTiming(a);
            if (c == "miss") _noteMiss();
            else if (c == "good") _noteGood();
            else if (c == "perfect") _notePerfect();
            else { }
        }
    }



    public void _noteMiss()
    {
        life--;
        if (life >= 0) { hp[life].sprite = heart[1]; }
        
    }
    public void _notePerfect() {
        score += 100;
    }
    public void _noteGood() {
        score += 50;
    }

    public sbyte getLife() {
        return life;
    }
    public int getScore() {
        return score;
    }

}
