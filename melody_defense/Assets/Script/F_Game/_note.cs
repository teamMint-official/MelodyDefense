using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _note : MonoBehaviour
{
    float noteSpeed = 384.0f;
    noteMgr n_mgr;
    byte x;
    // Start is called before the first frame update
    void OnEnable()
    {
        n_mgr = GameObject.Find("_noteMgr").GetComponent<noteMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!n_mgr.getPause())
        {
            transform.localPosition += Vector3.down * noteSpeed * Time.deltaTime;
        }
    }

    public void setX(byte a) {
        x = a;
    }
    public byte getX() {
        return x;
    }
}
