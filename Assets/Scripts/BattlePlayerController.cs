using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerController : MonoBehaviour
{
    [SerializeField] Animator anim;

    Singleton singleton;
    void Start()
    {
        singleton = Singleton.Instance;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (singleton.attack)
        {
            anim.SetBool("Attack1", true);
            singleton.attack = false;
        }
        else
        {
            anim.SetBool("Attack1", false);
        }

        if (singleton.magic)
        {
            anim.SetBool("Magic", true);
            singleton.magic = false;
        }
        else
        {
            anim.SetBool("Magic", false);
        }

        if (singleton.item)
        {
            anim.SetBool("Item", true);
            singleton.item = false;
        }
        else
        {
            anim.SetBool("Item", false);
        }
    }
}
