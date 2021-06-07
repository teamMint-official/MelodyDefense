using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListArray {
    public List<GameObject> _map;
}

public class timingMgr : MonoBehaviour
{
    public ListArray[] noteList = new ListArray[3];

    [SerializeField] Transform center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;
    string[] checking = { "perfect","good","miss"};

    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];

        for(int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.localPosition.y - timingRect[i].rect.height / 2,
                               center.localPosition.y + timingRect[i].rect.height / 2);

        }
    }


    public string checkTiming(short a) {//한 번에 한 라인만 판정
        if (noteList[a]._map.Count > 0)
        {
            float t_notePosY = noteList[a]._map[0].transform.localPosition.y;

            if (timingBoxs[2].x >= t_notePosY || t_notePosY >= timingBoxs[2].y)
            {
                return "none";
            }

            for (int y = 0; y < timingBoxs.Length; y++)
            {
                if (timingBoxs[y].x <= t_notePosY && t_notePosY <= timingBoxs[y].y)
                {
                    ObjectPool.instance.noteQueue.Enqueue(noteList[a]._map[0]);
                    noteList[a]._map[0].SetActive(false);
                    noteList[a]._map.RemoveAt(0);
                    return checking[y];
                }

            }

        }
        //}
        return "none";
    }
}
