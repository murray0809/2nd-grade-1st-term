using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffect : MonoBehaviour
{
    public GameObject particleObject;

    GameObject gameManager;

    GameManager manager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.playerAttack)
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        }
    }
}
