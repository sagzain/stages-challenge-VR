using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{   
    [SerializeField] private Light _light;
    [SerializeField] private AudioClip _sound;

    private bool _isActive;
    private AudioSource _audioSource;

    void Start()
    {
        _isActive = false;
        _light.enabled = _isActive;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        _isActive = !_isActive;
        _light.enabled = _isActive;
        _audioSource.PlayOneShot(_sound);
    }
}
