using System;
using System.Collections.Generic;
using UnityEngine;

public enum SFX
{
    click,
    shoot
}

[Serializable]
struct SFXConfig
{
    public SFX Type;
    public float VolumeScale;
    public AudioClip AudioClip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource environmentAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private SFXConfig[] SFXConfigs;

    private Dictionary<SFX, SFXConfig> SFXs;

    private void Awake()
    {
        // SFXs = SFXConfigs.ToDictionary(sfxConfig => sfxConfig.Type, sfxConfig => sfxConfig);
        SFXs = new Dictionary<SFX, SFXConfig>();
        foreach (SFXConfig config in SFXConfigs)
        {
            SFXs.Add(config.Type, config);
        }
    }

    public void PlaySFX(SFX type)
    {
        if (SFXs.ContainsKey(type))
        {
            SFXConfig config = SFXs[type];
            SFXAudioSource.PlayOneShot(config.AudioClip, config.VolumeScale);
        }
        else
        {
            Debug.LogError($"Failed to play sound of type {type}");
        }
    }
}
