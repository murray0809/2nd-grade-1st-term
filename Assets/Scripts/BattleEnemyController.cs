using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemyController : MonoBehaviour
{
    [SerializeField] float ATBspeed = 0.1f;

    [SerializeField] GameObject player = default;
    [SerializeField] Vector3 playerpos = default; //プレイヤーのポジション
    Vector3 direction;
    float speed = 2.0f;

    [SerializeField] int atk;
    [SerializeField] int mp;
    [SerializeField] int hpUp;

    int attackComand;
    bool move = false;
    bool attack = false;
    bool magic = false;
    bool heal = false;
    float attackCount = 0;
    float magicCount = 0;
    float healCount = 0;

    [SerializeField] Animator anim;
    GameObject gameManager;

    Vector3 startPos = new Vector3(-2f, 0f, -6f);
    Vector3 attackPos = new Vector3(0.2f, 0f, -7.5f);
    Vector3 playerPos = new Vector3(1f, 0f, -8f);

    public GameObject attackEffect;
    public GameObject magicEffect;
    public GameObject healEffect;

    GameManager manager;

    Singleton singleton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        direction = player.transform.position;

        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();

        attackEffect = GameObject.Find("AttackEffect");
        magicEffect = GameObject.Find("MagicEffect");
        healEffect = GameObject.Find("HealEffect");

        singleton = Singleton.Instance;
    }

    void Update()
    {

        manager.enemyATB.value += ATBspeed * Time.deltaTime;
        if (attack || magic || heal)
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
            
            manager.enemyATB.value = 0;
            Move();
            anim.SetBool("Attack1", true);
            attackCount += 0.1f;
            Debug.Log(attackCount);
            if (attackCount > 12f)
            {
                attack = false;
            }
        }
        else
        {
            ResetPos();
        }

        if (magic)
        {
            manager.enemyATB.value = 0;
            anim.SetBool("Magic", true);
            magicCount += 0.1f;
            Debug.Log(magicCount);
            if (magicCount > 10f)
            {
                
            }

            if (magicCount > 18f)
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
            if (healCount > 18f)
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

    void Move()
    {
        this.gameObject.transform.position = attackPos;
    }

    void ResetPos()
    {
        this.gameObject.transform.position = startPos;
        anim.SetBool("Attack1", false);
        attackCount = 0;
    }
    void Attack()
    {
        attack = true;
        manager.isAttaking = true;

        Instantiate(attackEffect, playerPos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成

        singleton.playerCurrentHp = singleton.playerCurrentHp - atk;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;

    }

    void Magic()
    {
        magic = true;
        manager.isAttaking = true;

        

        singleton.playerCurrentHp = singleton.playerCurrentHp - mp;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Heal()
    {
        heal = true;
        manager.isAttaking = true;
        manager.hp = manager.hp + hpUp;
        manager.enemySlider.value = (float)manager.hp / (float)manager.maxHp;
        manager.enemyATB.value = 0;
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
