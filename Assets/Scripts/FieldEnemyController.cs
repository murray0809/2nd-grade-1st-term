using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEnemyController : MonoBehaviour
{
    Singleton singleton;

    [SerializeField] GameObject player = default;
    [SerializeField] GameObject enemy = default;
    void Start()
    {
        singleton = Singleton.Instance;
        player = GameObject.FindGameObjectWithTag("FieldPlayer");
        enemy = GameObject.FindGameObjectWithTag("FieldEnemy");
    }
    void Update()
    {
        enemy.transform.LookAt(player.transform.position);
    }
}
