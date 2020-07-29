using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    PlayerBattleController playerScript;
    EnemyController enemyScript;
    Pointer pointerScript;

    int playerHp;
    int enemyHp;

    int playerMaxHp;
    int enemyMaxHp;

    public int pointer;

    public Text playerAttackText = default;
    public Text playerMagicText = default;
    public Text playerItemText = default;

    public Text enemyText = default;

    public Button attackBotton = default;
    public Button magicBotton = default;
    public Button itemBotton = default;

    public Slider playerSlider = default;
    public Slider enemySlider = default;

    public Slider playerATB = default;

    public Slider enemyATB = default;

    public float ATBspeed = 0.1f;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");

        playerScript = player.GetComponent<PlayerBattleController>();
        enemyScript = enemy.GetComponent<EnemyController>();
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

        playerMaxHp = playerScript.playerHp;
        enemyMaxHp = enemyScript.enemyHp;

        playerHp = playerScript.playerHp;
        enemyHp = enemyScript.enemyHp;

        Debug.Log("プレイヤーHP" + playerHp);
        Debug.Log("エネミーHP" + enemyHp);

        pointer = pointerScript.count;
    }

    void Update()
    {
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
    }

    public void Attack()
    {
        playerAttackText.text = "こうげき：1ダメージを与えた";
        enemyHp = enemyHp - 1;
        Invoke("DeleteText", 1.0f);
        Debug.Log("プレイヤー攻撃" + enemyHp);
        enemySlider.value = (float)enemyHp / (float)enemyMaxHp;
        if (enemyHp <= 0)
        {
            enemySlider.gameObject.SetActive(false);
            enemyScript.Destroy();
            Win();
        }
        playerATB.value = 0;
    }

    public void Magic()
    {
        playerMagicText.text = "まほう：2ダメージを与えた";
        enemyHp = enemyHp - 2;
        Invoke("DeleteText", 1.0f);
        Debug.Log("プレイヤーまほう" + enemyHp);
        enemySlider.value = (float)enemyHp / (float)enemyMaxHp;
        if (enemyHp <= 0)
        {
            enemySlider.gameObject.SetActive(false);
            enemyScript.Destroy();
            Win();
        }
        playerATB.value = 0;
    }

    public void Item()
    {
        playerItemText.text = "アイテムを使用した";
        playerHp = playerHp + 1;
        Invoke("DeleteText", 1.0f);
        Debug.Log("プレイヤーアイテム" + playerHp);
        playerSlider.value = (float)playerHp / (float)playerMaxHp;
        playerATB.value = 0;
    }

    public void EnemyAttack()
    {
        enemyText.text = "てきのこうげき：1ダメージを与えた";
        playerHp = playerHp - 1;
        Debug.Log("敵攻撃" + playerHp);
        Invoke("DeleteText", 1.0f);
        playerSlider.value = (float)playerHp / (float)playerMaxHp;
        if (playerHp <= 0)
        {
            playerSlider.gameObject.SetActive(false);
            playerScript.Destroy();
            GameOver();
        }
        enemyATB.value = 0;
    }


    void DeleteText()
    {
        playerAttackText.text = "";
        playerMagicText.text = "";
        playerItemText.text = "";
        enemyText.text = "";
    }
    void Win()
    {
        Debug.Log("Win");
    }

    void GameOver()
    {
        Debug.Log("ゲームオーバー");
    }
}
