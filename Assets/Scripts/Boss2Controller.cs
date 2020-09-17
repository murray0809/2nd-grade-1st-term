using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Controller : MonoBehaviour
{
    [SerializeField] float ATBspeed = 0.1f;

    int attackComand;

    bool attack = false;
    bool magic = false;
    bool heal = false;

    [SerializeField] Animator anim;
    GameObject gameManager;

    Boss2Manager manager;

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
            anim.SetBool("Attack1", true);
            attack = false;
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        if (magic)
        {
            anim.SetBool("Magic", true);
            magic = false;
        }
        else
        {
            anim.SetBool("Magic", false);
        }

        if (heal)
        {
            anim.SetBool("Heal", true);
            heal = false;
        }
        else
        {
            anim.SetBool("Heal", false);
        }
    }

    void Attack()
    {
        attack = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - 1;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Magic()
    {
        magic = true;
        singleton.playerCurrentHp = singleton.playerCurrentHp - 3;
        manager.playerSlider.value = (float)singleton.playerCurrentHp / (float)singleton.playerMaxHp;
        manager.enemyATB.value = 0;
    }

    void Heal()
    {
        heal = true;
        singleton.enemy1Hp = singleton.enemy1Hp + 3;
        manager.enemySlider.value = (float)singleton.enemy1Hp / (float)singleton.enemy1MaxHp;
        manager.enemyATB.value = 0;
    }
}
