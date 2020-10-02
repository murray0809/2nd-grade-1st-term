using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss2Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    Pointer pointerScript;

    public int pointer;

    [SerializeField] Animator anim;

    [SerializeField] public int maxHp;
    [SerializeField] public int hp;

    public Button attackBotton = default;
    public Button magicBotton = default;
    public Button itemBotton = default;

    public Slider playerSlider = default;
    public Slider enemySlider = default;

    public Slider playerATB = default;

    public Slider enemyATB = default;

    public float ATBspeed;

    public GameObject instance = default;

    Singleton singleton;

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;

    public bool isAttaking = false;

    public bool playerAttack = false;
    public bool playerMagic = false;
    public bool playerHeal = false;
    float count;

    public GameObject attackEffect;
    public GameObject magicEffect;
    public GameObject healEffect;

    bool attackEffectFlag = false;
    bool magicEffectFlag = false;
    bool healEffectFlag = false;

    float attackCount = 0;
    float magicCount = 0;
    float healCount = 0;

    Vector3 enemyPos = new Vector3(-2f, 1f, -6.5f);
    Vector3 attackPos = new Vector3(0.2f, 0f, -7.5f);
    Vector3 playerPos = new Vector3(1f, 1f, -8f);
    void Start()
    {
        player = GameObject.Find("BattlePlayer");
        enemy = GameObject.Find("BattleBoss");

        pointerScript = GetComponent<Pointer>();

        attackBotton = GameObject.Find("Attack").GetComponent<Button>();
        magicBotton = GameObject.Find("Magic").GetComponent<Button>();
        itemBotton = GameObject.Find("Item").GetComponent<Button>();

        playerSlider = GameObject.Find("PlayerHp").GetComponent<Slider>();
        enemySlider = GameObject.Find("EnemyHp").GetComponent<Slider>();

        playerATB = GameObject.Find("PlayerATB").GetComponent<Slider>();
        enemyATB = GameObject.Find("EnemyATB").GetComponent<Slider>();

        playerATB.value = Random.value;

        enemyATB.value = Random.value;

        pointer = pointerScript.count;

        anim = GetComponent<Animator>();

        singleton = Singleton.Instance;

        playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
    }

    void Update()
    {
        pointer = pointerScript.count;

        playerATB.value += ATBspeed * Time.deltaTime;

        //enemyATB.value += ATBspeed * Time.deltaTime;


        attackBotton.enabled = false;
        magicBotton.enabled = false;
        itemBotton.enabled = false;

        if (playerATB.value >= 1)
        {
            playerATB.value = 1;
            attackBotton.enabled = true;
            magicBotton.enabled = true;
            itemBotton.enabled = true;
            if (Input.GetButtonDown("Fire1") && pointer > -25)
            {
                Attack();
            }
            else if (Input.GetButtonDown("Fire1") && pointer <= -25 && pointer > -50)
            {
                Magic();
            }
            else if (Input.GetButtonDown("Fire1") && pointer <= -50 && pointer > -75)
            {
                Item();
            }
        }

        if (singleton.timeCount == 1)
        {
            RenderSettings.skybox = skybox1;
        }
        if (singleton.timeCount == 2)
        {
            RenderSettings.skybox = skybox2;
        }
        if (singleton.timeCount == 3)
        {
            RenderSettings.skybox = skybox3;
        }
        if (singleton.timeCount == 4)
        {
            RenderSettings.skybox = skybox4;
        }
        if (singleton.timeCount == 5)
        {
            RenderSettings.skybox = skybox5;
        }

        if (playerAttack)
        {
            playerATB.value = 0;
            count += 0.1f;
            if (count > 5f)
            {
                count = 0;
                playerAttack = false;
            }
        }
        else if (playerMagic)
        {
            playerATB.value = 0;
            count += 0.1f;
            if (count > 10f)
            {
                count = 0;
                playerMagic = false;
            }
        }
        else if (playerHeal)
        {
            playerATB.value = 0;
            count += 0.1f;
            if (count > 10f)
            {
                count = 0;
                playerHeal = false;
            }
        }

        if (attackEffectFlag)
        {
            attackCount += 0.1f;
            if (attackCount > 1f)
            {
                AttackEffect();
                attackCount = 0;
                hp = hp - singleton.playerAtk;
                Debug.Log("プレイヤー攻撃" + hp);
                enemySlider.value = (float)hp / (float)maxHp;
                attackEffectFlag = false;
            }
        }
        if (magicEffectFlag)
        {
            magicCount += 0.1f;
            if (magicCount > 15f)
            {
                MagicEffect();
                magicCount = 0;
                hp = hp - 10;
                Debug.Log("プレイヤーまほう" + hp);
                enemySlider.value = (float)hp / (float)maxHp;
                magicEffectFlag = false;
            }
        }
        if (healEffectFlag)
        {
            healCount += 0.1f;
            if (healCount > 5f)
            {
                HealEffect();
                healCount = 0;
                singleton.playerCurrentHp = singleton.playerCurrentHp + 1;
                if (singleton.playerCurrentHp > singleton.playerMaxHp)
                {
                    singleton.playerCurrentHp = singleton.playerMaxHp;
                }
                Debug.Log("プレイヤーアイテム" + singleton.playerCurrentHp);
                playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
                healEffectFlag = false;
            }
        }
    }

    public void Attack()
    {
        playerAttack = true;

        attackEffectFlag = true;
        singleton.attack = true;
       
        //if (singleton.enemy1Hp <= 0)
        //{
        //    enemySlider.gameObject.SetActive(false);
        //    Win();
        //    SceneManager.LoadScene("Island");
        //}
        playerATB.value = 0;
    }

    public void Magic()
    {
        playerMagic = true;
        singleton.magic = true;
        magicEffectFlag = true;
        //if (hp <= 0)
        //{
        //    enemySlider.gameObject.SetActive(false);
        //    Win();
        //    singleton.playerExp += 400;

        //    if (singleton.playerExp % 400 == 0)
        //    {
        //        LvUp();
        //    }
        //    SceneManager.LoadScene("Island");
        //}
        playerATB.value = 0;
    }

    public void Item()
    {
        playerHeal = true;
        singleton.item = true;
        healEffectFlag = true;
        playerATB.value = 0;
    }

    void Win()
    {
        singleton.deathFlag = true;
        Debug.Log("Win");
    }

    void LvUp()
    {
        singleton.playerLv++;
        Debug.Log("LvUp" + singleton.playerLv);
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
