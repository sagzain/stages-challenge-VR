using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform _output;
    [Range(1, 6)]
    [SerializeField] protected int _ammo;
    
    [Header("Sounds")]
    [SerializeField] protected AudioClip _shootSound;
    [SerializeField] protected AudioClip _emptySound;
    [SerializeField] protected AudioClip _reloadSound;
    [SerializeField] protected AudioClip _pickUpSound;

    protected int _currentAmmo;
    protected bool _canShoot;
    protected AudioSource _audioSource; 

    void Awake()
    {
        _canShoot = true;
        _audioSource = GetComponent<AudioSource>();
        _currentAmmo = _ammo;   
    }

    public void GrabGun()
    {
        if(_pickUpSound)
        {
            PlaySound(_pickUpSound);
        }
    }

    protected void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound);
    }
}
