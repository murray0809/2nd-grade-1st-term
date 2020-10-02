using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerAnim : MonoBehaviour
{
    [SerializeField] Animator anim;

    GameObject gameManager;

    Boss1Manager manager;

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
        if (manager.playerAttack)
        {
            anim.SetBool("Attack1", true);
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        if (manager.playerMagic)
        {
            anim.SetBool("Magic", true);
        }
        else
        {
            anim.SetBool("Magic", false);
        }


        if (manager.playerHeal)
        {
            anim.SetBool("Item", true);
        }
        else
        {
            anim.SetBool("Item", false);
        }
    }
}
