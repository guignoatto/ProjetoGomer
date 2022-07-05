using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class SoundBase : MonoBehaviour, ISoundBase
{

    [SerializeField] private GameObject _prefab;
    [Header("Mixer")]
    [SerializeField] private AudioMixerGroup _soundGroup;

    protected AudioSource _audioSource;
    protected void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlaySoundEffect(AudioClip clip, float volume = 1, float pitch = 1)
    {
        AudioSource aSource = Instantiate(_prefab , gameObject.transform).AddComponent<AudioSource>();
        aSource.playOnAwake = false;
        aSource.pitch = pitch;
        aSource.clip = clip;
        aSource.volume = volume;
        aSource.outputAudioMixerGroup = _soundGroup;
        aSource.Play();
        Destroy(aSource.gameObject, clip.length + 1);
    }
}
