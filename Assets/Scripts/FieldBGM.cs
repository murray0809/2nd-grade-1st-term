using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBGM : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip bgm = default;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSource.Play();
    }
}
