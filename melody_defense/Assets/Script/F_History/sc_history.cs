using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_history : MonoBehaviour
{

    public Text playCnt;
    public Text succesCnt;
    public Text perfectCnt;

    DataController mgr;



    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();

        playCnt.GetComponent<Text>().text = (mgr.get_playcnt()).ToString();
        succesCnt.GetComponent<Text>().text = (mgr.get_sucesscnt()).ToString();
        perfectCnt.GetComponent<Text>().text = (mgr.get_perfectcnt()).ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("_Lobby");
        }
    }
}
