using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public Text attackPointer = default;
    public Text magicPointer = default;
    public Text itemPointer = default;

    public int count = 0;

    public Slider playerATB;

    public float ATB = default;
    void Start()
    {
        attackPointer = GameObject.Find("AttackPointer").GetComponent<Text>();
        magicPointer = GameObject.Find("MagicPointer").GetComponent<Text>();
        itemPointer = GameObject.Find("ItemPointer").GetComponent<Text>();

        playerATB = GameObject.Find("PlayerATB").GetComponent<Slider>();
    }

    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");


        if (playerATB.value == 1)
        {
            if (v > 0)
            {
                count++;
            }
            if (v < 0)
            {
                count--;
            }

            if (count >= 0)
            {
                count = 0;
            }
            if (count <= -75)
            {
                count = -75;
            }
            if (count > -25)
            {
                attackPointer.gameObject.SetActive(true);
                magicPointer.gameObject.SetActive(false);
                itemPointer.gameObject.SetActive(false);
            }
            if (count <= -25 && count > -50)
            {
                attackPointer.gameObject.SetActive(false);
                magicPointer.gameObject.SetActive(true);
                itemPointer.gameObject.SetActive(false);
            }
            if (count <= -50 && count > -75)
            {
                attackPointer.gameObject.SetActive(false);
                magicPointer.gameObject.SetActive(false);
                itemPointer.gameObject.SetActive(true);
            }
        }
        else
        {
            attackPointer.gameObject.SetActive(false);
            magicPointer.gameObject.SetActive(false);
            itemPointer.gameObject.SetActive(false);
        }
    }
}
