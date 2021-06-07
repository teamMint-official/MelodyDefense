using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class noteMgr : MonoBehaviour
{
    int bpm = 60;
    double currentTime = 0d;
    bool isEnd;
    bool gameEnd_run;

    AudioSource _audio;
    DataController mgr;
    sc_playerCtl p_mgr;

    bool _isPause=false;
    public bool getPause() {
        return _isPause;
    }

    [SerializeField] Transform[] tfNoteAppear = null;

    timingMgr t_mgr;

    void Start()
    {
        gameEnd_run = false;
        isEnd = false;
        mgr = GameObject.Find("GameMgr").GetComponent<DataController>();
        t_mgr = GetComponent<timingMgr>();
        p_mgr = GameObject.Find("playerCtl").GetComponent<sc_playerCtl>();
        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        _audio.Stop();
        _audio.volume = ((float)mgr.getGame_vol()) / 500;
        StartCoroutine(waitStart());
    }

    IEnumerator waitStart() {
        yield return new WaitForSeconds(3.0f);
        if (!_isPause) {
            _audio.Play(); }
    }

    public IEnumerator gamefail() {
        yield return new WaitForSeconds(4.0f);
        mgr.increasePlayCnt();
        mgr.set_result(p_mgr.getLife(), p_mgr.getScore());
        SceneManager.LoadSceneAsync("_Result");
    }

    public IEnumerator gameEnd() {
        _audio.volume = 0;
        gameEnd_run = true;
        yield return new WaitForSeconds(4.0f);
        if (!_isPause)
        {
            mgr.increasePlayCnt();
            mgr.set_result(p_mgr.getLife(), p_mgr.getScore());
            SceneManager.LoadSceneAsync("_Result");
        }
        else {
            StartCoroutine(waitEnd());
        }
    }

    IEnumerator waitEnd() {
        IEnumerator ie = gameEnd();
        StopCoroutine(ie);
        top:
        while (_isPause) {
            yield return new WaitForSeconds(1.0f);
        }
        if (!_isPause)
        {
            SceneManager.LoadSceneAsync("_Result");
        }
        else {
            goto top;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!_isPause)
            {
                _Fn_pause();
                SceneManager.LoadSceneAsync("_Pause", LoadSceneMode.Additive);
            }
        }

        if (!_isPause)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 3d && !_audio.isPlaying) {
                _audio.Play();
            }
            if (currentTime >= (60d / bpm) + 5d)
            {
                if (_audio.clip.length - 5.0f > _audio.time && !isEnd)
                {
                    byte rand = (byte)Random.Range(0, 3);
                    GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = new Vector2(tfNoteAppear[rand].position.x, 
                        tfNoteAppear[rand].position.y + (mgr.getsink()/100));
                    t_note.SetActive(true);

                    t_note.gameObject.GetComponent<_note>().setX(rand);
                    t_mgr.noteList[rand]._map.Add(t_note);
                    currentTime -= 60d / bpm;//ct = 0으로 하면 오차가 날 수 있음.
                }
                else if (_audio.clip.length - 1.5f <= _audio.time)
                {
                    isEnd = true;
                    if(!gameEnd_run)StartCoroutine(gameEnd());
                }
            }
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (!_isPause)
        {
            _Fn_pause();
            SceneManager.LoadSceneAsync("_Pause", LoadSceneMode.Additive);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note")) {
            t_mgr.noteList[col.GetComponent<_note>().getX()]._map.Remove(col.gameObject);
            ObjectPool.instance.noteQueue.Enqueue(col.gameObject);
            col.gameObject.SetActive(false);
            p_mgr._noteMiss();
        }
    }//화면 밖으로 나가면 미스

    public void _Fn_pause() {
       _audio.Pause();
        _isPause = true;
    }
    public void _Fn_restart() {
        if (currentTime >= 3d) {
            _audio.Play();
        }
        _isPause = false;
    }
}
