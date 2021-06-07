using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gradient_test : MonoBehaviour
{
    public Gradient gra;

    [Range(0, 1)]
    public float t;

    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.color = gra.Evaluate(t);   
    }
}
