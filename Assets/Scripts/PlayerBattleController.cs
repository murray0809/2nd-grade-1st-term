using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleController : MonoBehaviour
{
    public int MaxHp;
    void Start()
    {
        MaxHp = 10;
    }

    void Update()
    {
        if (MaxHp <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
