using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] GameObject warp1;
    [SerializeField] GameObject player;
    void Start()
    {
        warp1 = GameObject.Find("Warp1");
        player = GameObject.FindGameObjectWithTag("FieldPlayer");
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FieldPlayer")
        {
            player.transform.position = warp1.transform.position;
        }
    }
}
