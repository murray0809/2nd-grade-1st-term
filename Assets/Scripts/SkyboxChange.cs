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

    public float time;

    public float skytime;
    public float skyspeed;

    public Light sun = default;
    //float intensity = default;

    bool reset = false;
    void Start()
    {
        time = 0f;
        reset = true;
        RenderSettings.skybox = skybox1;

        sun = GameObject.Find("Directional Light").GetComponent<Light>();
        sun.intensity = 0f;

        //intensity = sun.GetComponent<Light>().intensity;
        //GetComponent<Renderer>().material.SetFloat("_Blend", 0.5f);
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 0 && time < 3)
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
        if (time >= 3 && time < 6 )
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
        if (time >= 6 && time < 9)
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
        if (time >= 9 && time < 12)
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
        if (time >= 12 && time < 15)
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
        if (time >= 15f)
        {
            time = 0f;
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