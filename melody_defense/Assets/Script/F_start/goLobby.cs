using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goLobby : MonoBehaviour
{
    DataController _Dmgr;
    AudioSource _audio;
    _escape _e;
    double curTime;

    void Awake()
    {
        _Dmgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        _e = GetComponent<_escape>();
    }
   
    void Update()
    {
        curTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (curTime >= 3d)
            {
                if (!_e.sw)
                {
                    SceneManager.LoadScene("_Lobby");
                }
            }
        }
    }

}
