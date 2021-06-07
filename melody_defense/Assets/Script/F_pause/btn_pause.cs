using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_pause : MonoBehaviour
{
    noteMgr n_mgr;

    void Awake()
    {
        n_mgr = GameObject.Find("_noteMgr").GetComponent<noteMgr>();
    }

    public void OnClickExit()
    {
        SceneManager.LoadSceneAsync("_Lobby");
    }

    public void OnClickBack()
    {

        n_mgr._Fn_restart();
        SceneManager.UnloadSceneAsync("_Pause");

    }

}
