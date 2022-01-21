using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGun : Gun
{
    [Header("Bullet")]
    [SerializeField] private GameObject _bulletPrefab;

    private GameObject _bullet;

    void Start()
    {
        _bullet = Instantiate(_bulletPrefab, _output.position, transform.rotation);
        _bullet.transform.SetParent(_output);
        _bullet.transform.localPosition = _bulletPrefab.transform.position;
        _bullet.transform.localRotation = _bulletPrefab.transform.rotation;
    }

    public void Shoot()    
    {
        if(_canShoot)
        {
            PlaySound(_shootSound);
            _canShoot = false;
        }
        else
        {
            PlaySound(_emptySound);
        }
    }
}
