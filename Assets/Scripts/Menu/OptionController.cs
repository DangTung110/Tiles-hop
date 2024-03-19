using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField] private Slider volume;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject volumeOnObj, volumeOffObj;
    
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        VolumeChage();
        audioSource.Play();
    }
    public void VolumeChage()
    {
        audioMixer.SetFloat(Options.VOLUME, volume.value);
        if (volume.value > volume.minValue)
            SetVolumeButtonOn();
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
}
