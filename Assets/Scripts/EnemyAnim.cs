using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    [SerializeField] Animator anim;
    GameObject gameManager;

    GameManager manager;
    void Start()
    {
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.isAttaking)
        {
            anim.SetBool("Attack1", true);
            manager.isAttaking = false;
        }
        else
        {
            anim.SetBool("Attack1", false);
        }
    }
}
