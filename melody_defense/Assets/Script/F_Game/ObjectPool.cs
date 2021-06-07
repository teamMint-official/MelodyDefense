using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo {
    public GameObject goPrefab;
    public short cnt;
    public Transform tfPoolParent;
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectinfo = null;
    public static ObjectPool instance;

    public Queue<GameObject> noteQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        noteQueue = InsertQueue(objectinfo[0]);
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo) {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.cnt; i++) {
            GameObject t_clone = Instantiate(p_objectInfo.goPrefab,transform.position, Quaternion.identity);
            t_clone.SetActive(false);

            if (p_objectInfo.tfPoolParent != null)
            {
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);
            }
            else {
                t_clone.transform.SetParent(this.transform);
            }

            t_queue.Enqueue(t_clone);
        }
        return t_queue;
    }
}
