using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton mInstance;

    public int playerMaxHp = 10; //プレイヤーの最大HP
    public int playerCurrentHp = 10; //プレイヤーの現在HP
    public int playerMaxMp = 10; //プレイヤーの最大MP
    public int playerCurrentMp = 10; //プレイヤーの現在MP
    public int playerAtk = 5; //プレイヤーの攻撃力
    public int playerDef = 5; //プレイヤーの防御力

    public int enemyMaxHp = 10; //エネミーの最大HP
    public int enemyCurrentHp = 10; //エネミーの現在HP

    public int playerExp = 0;
    public int playerLv = 1;

    public GameObject enemy;

    public bool deathFlag = false;

    public bool start = true;

    public Vector3 playerPos;　//プレイヤーのポジション

    public int timeCount = 1;
    public float time = 0;
    private Singleton()
    { // Private Constructor

        Debug.Log("Create SampleSingleton instance.");
    }

    public static Singleton Instance
    {

        get
        {

            if (mInstance == null) mInstance = new Singleton();

            return mInstance;
        }
    }
}
