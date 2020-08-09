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

    void Start()
    {
        singleton = Singleton.Instance;
        Instantiate(obj, PlayerController.pos, Quaternion.identity);
        //Instantiate(cam, CameraController3.pos, Quaternion.identity);
        if (!singleton.deathFlag)
        {
            Instantiate(ene, enemyPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(singleton.enemy);
            singleton.deathFlag = true;
            SceneManager.LoadScene("Battle");
        }

       
    }
}
