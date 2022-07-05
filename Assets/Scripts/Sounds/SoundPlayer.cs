using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : SoundBase
{
    [Header("Player Sounds")]
    [SerializeField] private AudioClip _jumpSound;
    
    public void PlayJumpSound()
    {
        PlaySoundEffect(_jumpSound, 1,Random.Range(.7f,1.5f));
    }
}
