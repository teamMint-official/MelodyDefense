using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class musicList : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;
    AudioSource _audio;
    DataController mgr;
    [SerializeField] Text title;
    [SerializeField] Image bgImg;
    [SerializeField] Sprite[] imgList;
    string[] gameList = { "song0","song1"};

    short cur_music=0;
    short min = 0, max = 1;

    void Awake()
    {
        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();

        _audio.Stop();


        cur_music = mgr.getLastmusic();
        //마지막 숫자가 범위를 벗어났을 경우 대비
        if (cur_music > max) cur_music = min;
        else if (cur_music < min) cur_music = max;


        _audio.clip = _clips[cur_music];
        title.GetComponent<Text>().text = _clips[cur_music].name;
        bgImg.sprite = imgList[cur_music];
    }

    void Start()
    {
        _audio.volume = (float)mgr.getLobby_vol() / 500;
        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_music > max) cur_music = min;
        else if (cur_music < min) cur_music = max;

        title.GetComponent<Text>().text = _clips[cur_music].name;
        bgImg.sprite = imgList[cur_music];

        if (!_audio.isPlaying) {
            _audio.clip = _clips[cur_music];
            _audio.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mgr.setLastmusic(cur_music);
            SceneManager.LoadSceneAsync("_Lobby");
        }
    }

    public void next_mu() {
        _audio.Stop();
        cur_music++;
        mgr.setLastmusic(cur_music);
    }
    public void pre_mu() {
        _audio.Stop();
        cur_music--;
        mgr.setLastmusic(cur_music);
    }

    public void start_game() {
        mgr.setmName(_clips[cur_music].name);
        _audio.Stop();
        SceneManager.LoadSceneAsync("song0");
    }

}
