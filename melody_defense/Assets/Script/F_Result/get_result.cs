using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class get_result : MonoBehaviour
{
    [SerializeField] Text t;
    [SerializeField] Text score;
    [SerializeField] Text name;

    string[] res = { "Fail", "Sucess", "Perfect" };
    DataController mgr;
    void Awake()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();

        if (mgr.get_life() == 3)
        {
            t.GetComponent<Text>().text = res[2];
        }
        else if (mgr.get_life() < 1)
        {
            t.GetComponent<Text>().text = res[0];
        }
        else {
            t.GetComponent<Text>().text = res[1];
        }


        score.GetComponent<Text>().text = (mgr.get_score()).ToString();
        name.text = mgr.getmName();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("_StageSelect");
        }
    }
}
