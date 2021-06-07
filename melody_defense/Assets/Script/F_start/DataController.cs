using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    AudioSource _audio;
    GameObject e_sys;

    bool newplay = true;

    byte lobby_volume = 50;
    byte game_volume = 50;
    sbyte sink = 0;

    int play_count = 0;
    int sucess_count = 0;
    int perfect_count = 0;

    short last_music = 0;
    short sel_char = 0;

    sbyte life;
    int score;
    string mu_name;

    public delegate void SaveAllData();
    public SaveAllData _saveAll;//모든 데이터를 한번에 저장할 델리게이터

    public Sprite _idle;
    public Sprite _shoot;


    void Awake()
    {
        Load();
        if (newplay) {
            lobby_volume = 50;
            game_volume = 50;
            sink = 0;
            PlayerPrefs.SetInt("new",1);
        }


        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        e_sys = GameObject.Find("e_sys");

        _saveAll = new SaveAllData(SaveSound);
        _saveAll += new SaveAllData(SavePlay);
        _saveAll += new SaveAllData(SaveOther);

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_audio);
        DontDestroyOnLoad(e_sys);

        _audio.volume = (float)lobby_volume / 500;
        if (!_audio.isPlaying) _audio.Play();
    }

    void OnApplicationQuit(){
        _saveAll();
    }


    public void SaveSound()//사운드 관련 데이터만 저장
    {
        PlayerPrefs.SetInt("lobby_volume", lobby_volume);
        PlayerPrefs.SetInt("game_volume", game_volume);
        PlayerPrefs.SetInt("sink", sink);

    }
    public void SavePlay() {//플레이기록 관련 데이터만 저장
        PlayerPrefs.SetInt("play_count", play_count);
        PlayerPrefs.SetInt("sucess_count", sucess_count);
        PlayerPrefs.SetInt("perfect_count", perfect_count);
    }
    public void SaveOther() {//기타 데이터 저장
        PlayerPrefs.SetInt("last_music", last_music);
        PlayerPrefs.SetInt("sel_char", sel_char);
    }


    public void Load()
    {
        lobby_volume = (byte)PlayerPrefs.GetInt("lobby_volume");
        game_volume = (byte)PlayerPrefs.GetInt("game_volume");
        sink = (sbyte)PlayerPrefs.GetInt("sink");
        play_count = (sbyte)PlayerPrefs.GetInt("play_count");
        sucess_count = (sbyte)PlayerPrefs.GetInt("sucess_count");
        perfect_count = (sbyte)PlayerPrefs.GetInt("perfect_count");
        last_music = (sbyte)PlayerPrefs.GetInt("last_music");
        sel_char = (sbyte)PlayerPrefs.GetInt("sel_char");
        if (PlayerPrefs.GetInt("new") == 0)
        {
            newplay = true;
        }
        else {
            newplay = false;
        }
    }



    //history
    public void increasePlayCnt() {
        play_count++;
    }

    public int get_playcnt() {
        return play_count;
    }
    public int get_sucesscnt()
    {
        return sucess_count;
    }
    public int get_perfectcnt()
    {
        return perfect_count;
    }
    //dictionary
    public void set_selchar(short a) {
        sel_char = a;
    }
    public short getselchar() {
        return sel_char;
    }
    //game
    public void set_result(sbyte l, int s) {
        life = l;
        score = s;
        if (life == 3) {
            perfect_count++;
            sucess_count++;
        }
        else if (life < 1) { }
        else { sucess_count++; }

    }
    public sbyte get_life() {
        return life;
    }
    public int get_score() {
        return score;
    }

    //setting
    public byte getLobby_vol() {
        return lobby_volume;
    }
    public byte getGame_vol() {
        return game_volume;
    }
    public sbyte getsink() {
        return sink;
    }
    public void setLobby_vol(byte a) {
        lobby_volume = a;
    }
    public void setGame_vol(byte a) {
        game_volume = a;
    }
    public void setsink(sbyte a) {
        sink = a;
    }

    //stage
    public short getLastmusic() {
        return last_music;
    }
    public void setLastmusic(short a) {
        last_music = a;
    }

    public void setmName(string str) {
        mu_name = str;
    }
    public string getmName() {
        return mu_name;
    }
}
