using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    Pointer pointerScript;

    public int pointer;

    public Button attackBotton = default;
    public Button magicBotton = default;
    public Button itemBotton = default;

    public Slider playerSlider = default;
    public Slider enemySlider = default;

    public Slider playerATB = default;

    public Slider enemyATB = default;

    public float ATBspeed = 0.1f;

    public GameObject instance = default;

    [SerializeField] Text[] battleStatusText;

    Singleton singleton;

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;

    public bool isAttaking = false;
    void Start()
    {
        player = GameObject.Find("BattlePlayer");
        enemy = GameObject.Find("BattleEnemy");

        pointerScript = GetComponent<Pointer>();

        attackBotton = GameObject.Find("Attack").GetComponent<Button>();
        magicBotton = GameObject.Find("Magic").GetComponent<Button>();
        itemBotton = GameObject.Find("Item").GetComponent<Button>();

        playerSlider = GameObject.Find("PlayerHp").GetComponent<Slider>();
        enemySlider = GameObject.Find("EnemyHp").GetComponent<Slider>();

        playerATB = GameObject.Find("PlayerATB").GetComponent<Slider>();
        enemyATB = GameObject.Find("EnemyATB").GetComponent<Slider>();

        playerATB.value = Random.value;

        Debug.Log(playerATB.value);

        enemyATB.value = Random.value;

        Debug.Log(enemyATB.value);

        pointer = pointerScript.count;

        battleStatusText = new Text[4];
        battleStatusText[0] = GameObject.Find("HPdemo").GetComponent<Text>();
        battleStatusText[1] = GameObject.Find("MPdemo").GetComponent<Text>();
        battleStatusText[2] = GameObject.Find("ATKdemo").GetComponent<Text>();
        battleStatusText[3] = GameObject.Find("DEFdemo").GetComponent<Text>();

        singleton = Singleton.Instance;
    }

    void Update()
    {
        battleStatusText[0].text = "HP:" + singleton.playerCurrentHp;
        battleStatusText[1].text = "MP:" + singleton.playerCurrentMp;
        battleStatusText[2].text = "ATK:" + singleton.playerAtk;
        battleStatusText[3].text = "DEF:" + singleton.playerDef;

        pointer = pointerScript.count;

        playerATB.value += ATBspeed * Time.deltaTime;

        enemyATB.value += ATBspeed * Time.deltaTime;


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

        if (enemyATB.value >= 1)
        {
            enemyATB.value = 1;
            EnemyAttack();
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
    }

    public void Attack()
    {
        singleton.enemyCurrentHp = singleton.enemyCurrentHp - singleton.playerAtk;
        Debug.Log("プレイヤー攻撃" + singleton.enemyCurrentHp);
        enemySlider.value = (float)singleton.enemyCurrentHp / (float)singleton.enemyMaxHp;
        if (singleton.enemyCurrentHp <= 0)
        {
            enemySlider.gameObject.SetActive(false);
            Win();
            SceneManager.LoadScene("Island");
        }
        playerATB.value = 0;
    }

    public void Magic()
    {
        singleton.enemyCurrentHp = singleton.enemyCurrentHp - 10;
        Debug.Log("プレイヤーまほう" + singleton.enemyCurrentHp);
        enemySlider.value = (float)singleton.enemyCurrentHp / (float)singleton.enemyMaxHp;
        if (singleton.enemyCurrentHp <= 0)
        {
            enemySlider.gameObject.SetActive(false);
            Win();
            singleton.playerExp += 400;

            if (singleton.playerExp % 400 == 0)
            {
                LvUp();
            }
            SceneManager.LoadScene("Island");
        }
        playerATB.value = 0;
    }

    public void Item()
    {
        singleton.playerCurrentHp = singleton.playerCurrentHp + 1;
        Debug.Log("プレイヤーアイテム" + singleton.playerCurrentHp);
        playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        playerATB.value = 0;
    }

    public void EnemyAttack()
    {
        isAttaking = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - 1;
        Debug.Log("敵攻撃" + singleton.playerCurrentHp);
        playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        enemyATB.value = 0;
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
}
