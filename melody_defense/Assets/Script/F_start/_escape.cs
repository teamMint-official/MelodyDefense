using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _escape : MonoBehaviour
{
    public bool sw;
    AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = GameObject.Find("Main_bg").GetComponent<AudioSource>();
        sw = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!sw)
            {
                sw = true;
                _audio.Pause();
                SceneManager.LoadSceneAsync("_Exit", LoadSceneMode.Additive);
            }
        }
    }
}
