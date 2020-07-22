using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Suncontroller : MonoBehaviour
{

    public int sunspeed;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(Time.deltaTime * sunspeed, 0, 0);
    }
}