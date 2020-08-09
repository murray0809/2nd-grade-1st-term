using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEnemyController : MonoBehaviour
{
    Singleton singleton;
    void Start()
    {
        singleton = Singleton.Instance;
    }
    void Update()
    {
        gameObject.transform.LookAt(singleton.playerPos);
    }
}
