using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField] GameObject enemy = default;
    [SerializeField] int count = default;
    [SerializeField] float minX = default;
    [SerializeField] float maxX = default;
    [SerializeField] float minY = default;
    [SerializeField] float maxY = default;
    [SerializeField] float minZ = default;
    [SerializeField] float maxZ = default;
    Vector3 pos = default;
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            float randZ = Random.Range(minZ, maxZ);
            pos = new Vector3(randX, randY, randZ);
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
