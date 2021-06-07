using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sc_setting : MonoBehaviour
{

    public Text lv_val;
    public Text gv_val;
    public Text si_val;

    public Slider lv_sl;
    public Slider gv_sl;
    public Slider si_sl;

    AudioSource _au;
    DataController mgr;

    // Start is called before the first frame update
    void Start()
    {
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        _au = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        lv_sl.value = mgr.getLobby_vol();
        gv_sl.value = mgr.getGame_vol();
        si_sl.value = mgr.getsink();
    }

    // Update is called once per frame
    void Update()
    {
        lv_val.GetComponent<Text>().text = ((byte)lv_sl.value).ToString();
        gv_val.GetComponent<Text>().text = ((byte)gv_sl.value).ToString();
        si_val.GetComponent<Text>().text = ((sbyte)si_sl.value).ToString();
        mgr.setLobby_vol((byte)lv_sl.value);
        mgr.setGame_vol((byte)gv_sl.value);
        mgr.setsink((sbyte)si_sl.value);

        if ((int)lv_sl.value == 0) _au.Stop();
        else if ((int)lv_sl.value > 0 && !_au.isPlaying) _au.Play();

        _au.volume = (float)lv_sl.value/500;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("_Lobby");
        }
    }
}
