using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteDirection : MonoBehaviour
{
    //バトル時のキャラの向きを決めるスクリプト

    [SerializeField]  GameObject player = default;
    [SerializeField]  GameObject enemy = default;

    [SerializeField] Vector3 playerpos = default; //プレイヤーのポジション
    [SerializeField] Vector3 enemypos = default; //エネミーのポジション
    void Start()
    {
        player = GameObject.Find("BattlePlayer");
        enemy = GameObject.Find("BattleEnemy");

        playerpos = player.transform.position;　//プレイヤーのポジションの代入
        enemypos = enemy.transform.position;　//プレイヤーのポジションの代入

        player.transform.LookAt(enemypos); //プレイヤーがエネミーを向くようにする
        enemy.transform.LookAt(playerpos); //エネミーがプレイヤーを向くようにする
    }
}
