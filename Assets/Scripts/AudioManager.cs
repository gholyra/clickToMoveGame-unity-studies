using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum SFX
{

}

[Serializable]
struct SFXConfig
{
    public SFX Type;
    public float VolumeScale;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource environmentAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;
    [SerializeField] private SFXConfig[] SFXConfigs;

    private Dictionary<SFX, SFXConfig> SFXs;

    private void Awake()
    {
        SFXs = SFXConfigs.ToDictionary(sfxConfig => sfxConfig.Type, sfxConfig => sfxConfig);
    }

    private void PlaySFX(SFX type)
    {

    }
}
