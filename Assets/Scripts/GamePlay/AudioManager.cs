using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] clips;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        audio.clip = clips[Game.MAP];
        audio.Play();
    }
}
