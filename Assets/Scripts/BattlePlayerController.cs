using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour
{
    [SerializeField] Animator anim;

    public GameObject attackEffect;
    public GameObject magicEffect;
    public GameObject healEffect;

    Vector3 enemyPos = new Vector3(-2f, 0f, -6.5f);
    Vector3 attackPos = new Vector3(0.2f, 0f, -7.5f);
    Vector3 playerPos = new Vector3(1f, 0f, -8f);

    Singleton singleton;
    void Start()
    {
        singleton = Singleton.Instance;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (singleton.attack)
        {
            AttackEffect();
            anim.SetBool("Attack1", true);
            singleton.attack = false;
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        if (singleton.magic)
        {
            MagicEffect();
            anim.SetBool("Magic", true);
            singleton.magic = false;
        }
        else
        {
            anim.SetBool("Magic", false);
        }

        if (singleton.item)
        {
            HealEffect();
            anim.SetBool("Item", true);
            singleton.item = false;
        }
        else
        {
            anim.SetBool("Item", false);
        }
    }

    void AttackEffect()
    {
        Instantiate(attackEffect, enemyPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }
    void MagicEffect()
    {
        Instantiate(magicEffect, enemyPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }

    void HealEffect()
    {
        Instantiate(healEffect, playerPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }
}
