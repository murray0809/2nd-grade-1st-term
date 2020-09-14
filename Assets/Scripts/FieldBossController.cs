using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldBossController : MonoBehaviour
{
    Singleton singleton;

    [SerializeField] GameObject player = default;
    [SerializeField] GameObject boss1 = default;
    [SerializeField] GameObject boss2 = default;
    void Start()
    {
        singleton = Singleton.Instance;
        player = GameObject.FindGameObjectWithTag("FieldPlayer");
        boss1 = GameObject.FindGameObjectWithTag("FieldBoss1");
        boss2 = GameObject.FindGameObjectWithTag("FieldBoss2");
    }

    void Update()
    {
        boss1.transform.LookAt(player.transform.position);
        boss2.transform.LookAt(player.transform.position);

        if (singleton.timeCount <= 3)
        {
            boss1.SetActive(true);
            boss2.SetActive(false);
        }
        else
        {
            boss1.SetActive(false);
            boss2.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FieldPlayer" && singleton.timeCount <= 3)
        {
            SceneManager.LoadScene("Boss1");
        }
        if (collision.gameObject.tag == "FieldPlayer" && singleton.timeCount > 3)
        {
            SceneManager.LoadScene("Boss2");
        }
    }
}
