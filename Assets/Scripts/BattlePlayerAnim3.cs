﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerAnim3 : MonoBehaviour
{
    [SerializeField] Animator anim;

    GameObject gameManager;

    GameManager manager;

    Singleton singleton;
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();

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
