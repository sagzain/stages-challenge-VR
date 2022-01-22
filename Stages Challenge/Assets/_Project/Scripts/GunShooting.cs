using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunShooting : MonoBehaviour
{
    [SerializeField] protected Transform _output;
    [Range(1, 6)]
    [SerializeField] protected int _ammo;
    
    [Header("Sounds")]
    [SerializeField] protected AudioClip _shootSound;
    [SerializeField] protected AudioClip _emptySound;
    [SerializeField] protected AudioClip _reloadSound;
    [SerializeField] protected AudioClip _pickUpSound;

    [Header("Bullet")]
    [SerializeField] private GameObject _bulletPrefab;

    private GameObject _bullet;
    protected int _currentAmmo;
    protected bool _canShoot;
    private Animator _animator;
    protected AudioSource _audioSource; 

    void Awake()
    {
        _canShoot = true;
        _audioSource = GetComponent<AudioSource>();
        _currentAmmo = _ammo;   
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _bullet = Instantiate(_bulletPrefab, _output.position, _output.rotation);
        _bullet.transform.SetParent(_output);
        _bullet.transform.localPosition = Vector3.zero;
        // _bullet.transform.localRotation = _bulletPrefab.transform.rotation;
    }

    public void Shoot()    
    {
        if(_canShoot)
        {
            PlaySound(_shootSound);
            _animator.SetTrigger("Fire");
            _bullet.GetComponent<ShotBehaviour>().Fire();
            _currentAmmo--;

            if(_currentAmmo > 0)
            {
                _bullet = Instantiate(_bulletPrefab, _output.position, transform.rotation);
                _bullet.transform.SetParent(_output);
                _bullet.transform.localPosition = _bulletPrefab.transform.position;
                _bullet.transform.localRotation = _bulletPrefab.transform.rotation;
            }
            else
            {
                _canShoot = false;
            }
        }
        else
        {
            PlaySound(_emptySound);
        }
    }

    public void GrabGun()
    {
        PlaySound(_pickUpSound);
    }

    protected void PlaySound(AudioClip sound)
    {
        if(sound)
        {
            _audioSource.PlayOneShot(sound);
        } 
    }
}
