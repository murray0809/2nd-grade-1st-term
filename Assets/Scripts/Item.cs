using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject player;
   
    Singleton singleton;
    void Start()
    {
        player = GameObject.Find("Player");

        singleton = Singleton.Instance;
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            singleton.playerMaxHp += 1;
            Destroy(this.gameObject);
        }
    }
}
