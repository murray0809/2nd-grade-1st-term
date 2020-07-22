using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    Button btn;
    void Start()
    {
        btn = GameObject.Find("Button").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
       btn.enabled = false;
    }
}
