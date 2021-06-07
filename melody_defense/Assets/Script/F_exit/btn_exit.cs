using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_exit : MonoBehaviour
{

    DataController mgr;
    AudioSource _audio;
    _escape _e;
    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        _e = GameObject.Find("camera").GetComponent<_escape>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
           ClickBack();
        }
    }

    public void ClickExit() {
        mgr._saveAll();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    public void ClickBack() {
        if (_e.sw)
        {
            _e.sw = false;
            _audio.Play();
            SceneManager.UnloadSceneAsync("_Exit");
        }
    }

}
