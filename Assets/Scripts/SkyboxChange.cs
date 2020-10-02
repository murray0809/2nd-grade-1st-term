using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    // 事前にInspectorから設定した、Skyboxのマテリアル
    public Material skybox1;
    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;

    //public float singletontime;

    public float skytime;
    public float skyspeed;

    public Light sun = default;

    bool reset = false;

    Singleton singleton;
    void Start()
    {
        singleton = Singleton.Instance;

        reset = true;
        RenderSettings.skybox = skybox1;

        sun = GameObject.Find("Directional Light").GetComponent<Light>();
        sun.intensity = 0f;
    }
    void Update()
    {
        singleton.time += Time.deltaTime;

        if (singleton.timeCount == 1)
        {
            if (singleton.time >= 0 && singleton.time < 10)
            {
                sun.intensity += 0.3f * Time.deltaTime;
                if (reset)
                {
                    SkytimeReset();
                    reset = false;
                }
                RenderSettings.skybox = skybox1;// Skyboxの変更
                skytime += skyspeed * Time.deltaTime;
                if (skytime >= 1)
                {
                    skytime = 1f;
                }
                if (sun.intensity >= 0.7)
                {
                    sun.intensity = 0.7f;
                }
            }
            if (singleton.time >= 10)
            {
                singleton.timeCount = 2;
            }
        }

        if (singleton.timeCount == 2)
        {
            if (singleton.time >= 10 && singleton.time < 20)
            {
                sun.intensity += 0.3f * Time.deltaTime;
                if (!reset)
                {
                    SkytimeReset();
                    reset = true;
                }
                RenderSettings.skybox = skybox2;
                
                skytime += skyspeed * Time.deltaTime;
                if (skytime >= 1)
                {
                    skytime = 1f;
                }
                if (sun.intensity >= 1)
                {
                    sun.intensity = 1f;
                }
            }
            if (singleton.time >= 20)
            {
                singleton.timeCount = 3;
            }
        }

        if (singleton.timeCount == 3)
        {
            if (singleton.time >= 20 && singleton.time < 30)
            {
                sun.intensity -= 0.3f * Time.deltaTime;
                if (reset)
                {
                    SkytimeReset();
                    reset = false;
                }
                RenderSettings.skybox = skybox3;
             
                skytime += skyspeed * Time.deltaTime;
                if (skytime >= 1)
                {
                    skytime = 1f;
                }
                if (sun.intensity <= 0.5)
                {
                    sun.intensity = 0.5f;
                }
            }
            if (singleton.time >= 30)
            {
                singleton.timeCount = 4;
            }
        }

        if (singleton.timeCount == 4)
        {
            if (singleton.time >= 30 && singleton.time < 40)
            {
                sun.intensity -= 0.3f * Time.deltaTime;
                if (!reset)
                {
                    SkytimeReset();
                    reset = true;
                }
                RenderSettings.skybox = skybox4;

                skytime += skyspeed * Time.deltaTime;
                if (skytime >= 1)
                {
                    skytime = 1f;
                }
                if (sun.intensity <= 0.3)
                {
                    sun.intensity = 0.3f;
                }
            }
            if (singleton.time >= 40)
            {
                singleton.timeCount = 5;
            }
        }

        if (singleton.timeCount == 5)
        {
            if (singleton.time >= 40 && singleton.time < 50)
            {
                sun.intensity -= 0.3f * Time.deltaTime;
                if (reset)
                {
                    SkytimeReset();
                    reset = false;
                }
                RenderSettings.skybox = skybox5;

                skytime += skyspeed * Time.deltaTime;
                if (skytime >= 1)
                {
                    skytime = 1f;
                }
            }
            if (singleton.time >= 50)
            {
                singleton.timeCount = 1;
            }
        }
       
        if (singleton.time >= 50f)
        {
            singleton.time = 0f;
            reset = true;
        }
        if (sun.intensity <= 0)
        {
            sun.intensity = 0f;
        }

        RenderSettings.skybox.SetFloat("_Blend", skytime);
    }

    void SkytimeReset()
    {
        skytime = 0f;
    }
}