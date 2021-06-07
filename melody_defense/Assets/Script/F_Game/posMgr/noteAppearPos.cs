using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace position
{
    public class noteAppearPos : MonoBehaviour
    {
        float x;
        [SerializeField] sbyte check;
        // Start is called before the first frame update
        void Awake()
        {
            if (check == -1)
            {
                x = -(Screen.width / 3);
            }
            else if (check == 0)
            {
                x = 0;
            }
            else if (check == 1)
            {
                x = (Screen.width / 3);
            }
            gameObject.GetComponent<RectTransform>().position = new Vector3(x, Screen.height / 2, 0);
        }


    }
}
