using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton mInstance;

    public int playerMaxHp = 100; //プレイヤーの最大HP
    public int playerCurrentHp = 100; //プレイヤーの現在HP
    public int playerMaxMp = 10; //プレイヤーの最大MP
    public int playerCurrentMp = 10; //プレイヤーの現在MP
    public int playerAtk = 5; //プレイヤーの攻撃力
    public int playerDef = 5; //プレイヤーの防御力

    public int enemy1MaxHp = 10; //エネミー1の最大HP
    public int enemy1Hp = 10; //エネミー1の現在HP

    public int boss1MaxHp = 100;
    public int boss1Hp = 100;

    public int playerExp = 0;
    public int playerLv = 1;

    public GameObject enemy;

    public bool deathFlag = false;

    public bool start = true;

    public Vector3 playerPos;　//プレイヤーのポジション

    public int timeCount = 1;
    public float time = 0;

    public bool attack = false;
    public bool magic = false;
    public bool item = false;
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
