using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_pause : MonoBehaviour
{
    noteMgr n_mgr;
    // Start is called before the first frame update
    void Start()
    {
        n_mgr = GameObject.Find("_noteMgr").GetComponent<noteMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            n_mgr._Fn_restart();
            SceneManager.UnloadSceneAsync("_Pause");
        }
    }
}
