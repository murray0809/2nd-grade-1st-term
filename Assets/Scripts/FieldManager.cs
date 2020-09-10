using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] int count;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;
    Vector3 pos;
    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float randX = Random.Range(minX, maxX);
            float randY = Random.Range(minY, maxY);
            float randZ = Random.Range(minY, maxZ);
            pos = new Vector3(randX, randY, randZ);
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
