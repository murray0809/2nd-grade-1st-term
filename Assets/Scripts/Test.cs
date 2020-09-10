using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject obj;
    //public GameObject cam;
    Singleton singleton;
    public GameObject ene; 
    Vector3 enemyPos = new Vector3(-2f, 0f, 3f);
    Vector3 startPos;

    void Awake()
    {
        singleton = Singleton.Instance;
        if (singleton.start)
        {
            startPos = this.gameObject.transform.position;
            Debug.Log(startPos);
            Instantiate(obj, startPos, Quaternion.identity);
            singleton.start = false;
        }
        else
        {
            Instantiate(obj, PlayerController.pos, Quaternion.identity);
        }
    }

    void Update()
    {
       
    }
}
