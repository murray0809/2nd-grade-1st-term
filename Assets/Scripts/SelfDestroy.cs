using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    float count = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        count += 0.1f;

        if (count > 5f)
        {
            Destroy(this.gameObject);
        }
    }
}
