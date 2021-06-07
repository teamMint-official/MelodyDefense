using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace position
{
    public class checkPos : MonoBehaviour
    {
        [SerializeField]bool _isSize = false;
        float magni;
        RectTransform r;
        // Start is called before the first frame update
        void Awake()
        {
            r = gameObject.GetComponent<RectTransform>();
            if (_isSize)
            {
                magni = 1980 / Screen.height;
                r.sizeDelta = new Vector2( r.sizeDelta.x , r.sizeDelta.y * magni);
            }
           r.position = new Vector3( 0f , -Screen.height/5 , 0f);
        }
    }
}
