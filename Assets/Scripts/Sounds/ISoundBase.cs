using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundBase
{
    public void PlaySoundEffect(AudioClip clip, float volume = 1, float pitch = 1);
}
