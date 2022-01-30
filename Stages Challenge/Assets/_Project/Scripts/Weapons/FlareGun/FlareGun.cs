using UnityEngine;

public class FlareGun : Weapon
{
    [Header("Others")]
    [SerializeField] private GameObject _flarePrefab;
    
    private GameObject _flareBullet;

    void Start()
    {
        _flareBullet = Instantiate(_flarePrefab, _output.position, _output.rotation);
        _flareBullet.transform.SetParent(_output);
        _flareBullet.transform.localPosition = Vector3.zero;
    }

    public void ShootFlareGun()
    {
        if(_canShoot)
        {
            Destroy(_flareBullet);
        }

        base.ShootWeapon();
    }
}
