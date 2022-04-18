using UnityEngine;
using UnityEngine.Serialization;

public class PlayerSounds : MonoBehaviour
{
    [FormerlySerializedAs("audioClip")] public AudioClip jump;
    private AudioSource _audioSource;

    public void PlaySound(AudioClip _audio)
    {
        _audioSource.clip = _audio;
        _audioSource.pitch = Random.Range(0.9f, 1.3f);
        _audioSource.Play();
    }
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
}
