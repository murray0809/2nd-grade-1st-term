using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] float ATBspeed = 0.1f;

    [SerializeField] int atk;
    [SerializeField] int mp;
    [SerializeField] int hpUp;

    Vector3 startPos = new Vector3(-2f, 0f, -6f);
    Vector3 attackPos = new Vector3(0.2f, 0f, -7.5f);
    Vector3 playerPos = new Vector3(1f, 1f, -8f);

    int attackComand;

    bool attack = false;
    bool magic = false;
    bool heal = false;
    float attackCount = 0;
    float magicCount = 0;
    float healCount = 0;

    [SerializeField] Animator anim;
    GameObject gameManager;

    Boss1Manager manager;

    public GameObject attackEffect;
    public GameObject magicEffect;
    public GameObject healEffect;

    Singleton singleton;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<Boss1Manager>();

        singleton = Singleton.Instance;
    }

    void Update()
    {
        manager.enemyATB.value += ATBspeed * Time.deltaTime;

        if (manager.enemyATB.value >= 1)
        {
            manager.enemyATB.value = 1;

            attackComand = Random.Range(1, 4);
            Debug.Log(attackComand);

            if (attackComand == 1)
            {
                Attack();
            }
            else if (attackComand == 2)
            {
                Magic();
            }
            else if (attackComand == 3)
            {
                Heal();
            }

        }

        if (attack)
        {
            manager.enemyATB.value = 0;
            anim.SetBool("Attack1", true);
            attackCount += 0.1f;
            Debug.Log(attackCount);
            if (attackCount > 20f)
            {
                AttackEffect();
                attack = false;
                attackCount = 0;
            }
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        if (magic)
        {
            manager.enemyATB.value = 0;
            anim.SetBool("Magic", true);
            magicCount += 0.1f;
            if (magicCount > 20f)
            {
                MagicEffect();
                magic = false;
                magicCount = 0;
            }
        }
        else
        {
            anim.SetBool("Magic", false);
        }

        if (heal)
        {
            manager.enemyATB.value = 0;
            anim.SetBool("Heal", true);
            healCount += 0.1f;
            if (healCount > 20f)
            {
                HealEffect();
                heal = false;
                healCount = 0;
            }
        }
        else
        {
            anim.SetBool("Heal", false);
        }
    }

    void Attack()
    {
        attack = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - atk;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Magic()
    {
        magic = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - mp;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Heal()
    {
        heal = true;
        manager.hp = manager.hp + hpUp;
        manager.enemySlider.value = (float)manager.hp / (float)manager.maxHp;
        manager.enemyATB.value = 0;
    }

    void AttackEffect()
    {
        Instantiate(attackEffect, playerPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }
    void MagicEffect()
    {
        Instantiate(magicEffect, playerPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }

    void HealEffect()
    {
        Instantiate(healEffect, startPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    }
}
