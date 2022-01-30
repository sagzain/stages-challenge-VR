using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _output;
    [SerializeField] private GameObject _shotPrefab;

    [Header("Sounds")]
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _emptySound;
    [SerializeField] private AudioClip _reloadSound;
    [SerializeField] private AudioClip _pickupSound;

    protected bool _canShoot;

    private Animator _animator;
    private AudioSource _audioSource;

    void Awake()
    {
        _canShoot = true;
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void ShootWeapon()
    {
        if(_canShoot) 
        {
            PlaySound(_shootSound);
            Instantiate(_shotPrefab, _output.position, _output.rotation);
            _animator.SetTrigger("Fire");
        }
        else
        {
            PlaySound(_emptySound);
        }
    }

    public void GrabWeapon()
    {
        PlaySound(_pickupSound);
    }

    public void ReloadWeapon()
    {
        PlaySound(_reloadSound);
    }

    void PlaySound(AudioClip audio)
    {
        if(audio)
        {
            _audioSource.PlayOneShot(audio);
        }
    }
}
