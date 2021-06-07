using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_stage : MonoBehaviour
{
    string[] stageList;
    musicList ml;

    private void Awake()
    {
        ml = GameObject.Find("MusicList").GetComponent<musicList>();
    }

    public void OnNext() {
        ml.next_mu();
    }

    public void OnPre()
    {
        ml.pre_mu();
    }

    public void OnStart() {
        ml.start_game();
    }

}
