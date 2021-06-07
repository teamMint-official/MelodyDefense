using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_lobby : MonoBehaviour
{

    public void goDictionary() {
        SceneManager.LoadSceneAsync("_Dictionary");
    }
    public void goHistory()
    {
        SceneManager.LoadSceneAsync("_History");
    }
    public void goSetting()
    {
        SceneManager.LoadSceneAsync("_Setting");
    }
    public void goStageSelect()
    {
        SceneManager.LoadSceneAsync("_StageSelect");
    }
}
