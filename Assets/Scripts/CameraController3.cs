using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3 : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;
    Vector3 distance = new Vector3(0f, 1f, -3f);

    public static Vector3 pos;
    void Start()
    {
        targetObj = GameObject.FindGameObjectWithTag("FieldPlayer");
        targetPos = targetObj.transform.position;
        this.gameObject.transform.position = targetPos + distance;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの右クリックを押している間
        
            // マウスの移動量
            float mouseInputX = Input.GetAxis("RHorizontal");
            float mouseInputY = Input.GetAxis("RVertical");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);

        //pos = this.transform.position;
        //Debug.Log(pos);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FieldEnemy")
        {
            pos = this.transform.position;
            Debug.Log(pos);
        }
    }
}
