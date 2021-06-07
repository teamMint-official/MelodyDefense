using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_lobby : MonoBehaviour
{
    [SerializeField] AudioClip _mainbg;
    AudioSource _audio;
    DataController mgr;
    _escape _e;

    [SerializeField] Sprite[] idle;
    [SerializeField] Sprite[] shoot;

    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        _e = GetComponent<_escape>();

        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        _audio.clip = _mainbg;
        _audio.volume = (float)mgr.getLobby_vol() / 500;

        if (!_audio.isPlaying) _audio.Play();


        short getch = mgr.getselchar();
        mgr._idle = idle[getch];
        mgr._shoot = shoot[getch];
    }
}
