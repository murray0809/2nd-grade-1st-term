using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    [SerializeField] float ATBspeed = 0.1f;

    int attackComand;

    [SerializeField] int atk;
    [SerializeField] int mp;
    [SerializeField] int hpUp;

    Vector3 startPos = new Vector3(-2f, 0f, -6.5f);
    Vector3 attackPos = new Vector3(0.2f, 0f, -7.5f);
    Vector3 playerPos = new Vector3(1f, 0f, -8f);

    bool attack = false;
    bool magic = false;
    bool heal = false;
    float attackCount = 0;
    float magicCount = 0;
    float healCount = 0;

    bool magicFlag = false;

    [SerializeField] Animator anim;
    GameObject gameManager;

    Boss2Manager manager;

    public GameObject attackEffect;
    public GameObject magicEffect;
    public GameObject healEffect;

    bool attackEffectFlag = false;
    public float attackEffectCount = 0;
    bool magicEffectFlag = false;
    public float magicEffectCount = 0;

    bool atb = true;

    Singleton singleton;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<Boss2Manager>();

        singleton = Singleton.Instance;
    }

    void Update()
    {
        if (atb)
        {
            manager.enemyATB.value += ATBspeed * Time.deltaTime;
        }
        else
        {
            manager.enemyATB.value = 0;
        }
       

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
            atb = false;
            anim.SetBool("Attack1", true);
            attackCount += 0.1f;
            
            Debug.Log(attackCount);
            
            if (attackCount > 15f)
            {
                attack = false;
                atb = true;
                attackCount = 0;
            }
        }
        else
        {
            anim.SetBool("Attack1", false);
        }


        if (attackEffectFlag)
        {
            magicEffectCount += 0.1f;
            if (magicEffectCount > 3f)
            {
                AttackEffect();
                attackEffectFlag = false;
                magicEffectCount = 0;
            }
        }

        if (magic)
        {
            magicFlag = true;
            atb = false;
            anim.SetBool("Magic", true);
            magicCount += 0.1f;
            if (magicCount > 30f && magicFlag)
            {
                
                magicFlag = false;
            }

            if (magicCount > 50f)
            {
                magic = false;
                atb = true;
                magicCount = 0;
            }
        }
        else
        {
            anim.SetBool("Magic", false);
        }

        if (magicEffectFlag)
        {
            magicEffectCount += 0.1f;
            if (magicEffectCount > 20f)
            {
                MagicEffect();
                magicEffectFlag = false;
                magicEffectCount = 0;
            }
        }

        if (heal)
        {
            atb = false;
            anim.SetBool("Heal", true);
            healCount += 0.1f;
            if (healCount > 20f)
            {
                HealEffect();
                heal = false;
                atb = true;
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
        attackEffectFlag = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - atk;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Magic()
    {
        magic = true;
        magicEffectFlag = true;
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
