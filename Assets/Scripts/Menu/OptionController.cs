using System;
using System.IO;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField] private Slider volume;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject volumeOnObj, volumeOffObj;
    private string pathVolume = Application.streamingAssetsPath + "/volume.txt";

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        SetVolume();
        VolumeChage();
        audioSource.Play();
    }
    public void VolumeChage()
    {
        audioMixer.SetFloat(Options.VOLUME_TEXT, volume.value);
        if (volume.value > volume.minValue)
            SetVolumeButtonOn();
        string[] arr = { volume.value.ToString() };
        File.WriteAllLines(pathVolume, arr);
    }
    public void SetVolumeButtonOn()
    {
        volumeOnObj.SetActive(true);
        volumeOffObj.SetActive(false);
    }
    public void SetVolumeButtonOff()
    {
        volumeOnObj.SetActive(false);
        volumeOffObj.SetActive(true);
        volume.value = volume.minValue;
    }
    private void SetVolume()
    {
        try
        {
            string[] arr = File.ReadAllLines(pathVolume);
            volume.value = float.Parse(arr[0]);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
