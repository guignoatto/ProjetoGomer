using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSounds : SoundBase
{
    [Header("Bg Sounds")]
    [SerializeField] private AudioClip _bgSongLvl1;
    [SerializeField] private AudioClip _birdsSound;

    private void PlayBgSongLvl1()
    {
        _audioSource.clip = _bgSongLvl1;
        _audioSource.Play();
    }

    private void PlayBirdSounds()
    {
        PlaySoundEffect(_birdsSound);
    }
}
