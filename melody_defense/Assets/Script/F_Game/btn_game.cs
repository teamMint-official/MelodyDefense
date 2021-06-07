using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_game : MonoBehaviour
{
    noteMgr n_mgr;

    void Awake() {
        n_mgr = GameObject.Find("_noteMgr").GetComponent<noteMgr>();
    }

    public void clickPause()
    {
        n_mgr._Fn_pause();
        SceneManager.LoadSceneAsync("_Pause", LoadSceneMode.Additive);
    }
}
