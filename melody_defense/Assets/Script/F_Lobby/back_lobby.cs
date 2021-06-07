using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_lobby : MonoBehaviour
{

    DataController mgr;

    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
    }

    // Update is called once per frame
    public void OnClick() {
        SceneManager.LoadSceneAsync("_Lobby");
    }

    public void _ifStage() {
        mgr.SaveOther();
    }

    public void _ifDict() {
        mgr.SaveOther();
    }

    public void _ifSetting() {
        //mgr.setLobby_vol();
        //mgr.setGame_vol();
        mgr.SaveSound();
    }
}
