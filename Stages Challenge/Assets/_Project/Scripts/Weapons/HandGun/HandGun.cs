using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandGun : Weapon
{
    [SerializeField] private XRSocketInteractor _ammoSocket;

    private Magazine _currentMagazine;

    void Start()
    {
        try {_currentMagazine = _ammoSocket.firstInteractableSelected.transform.gameObject.GetComponent<Magazine>();}catch{}
        _ammoSocket.selectEntered.AddListener(AddMagazine);
        _ammoSocket.selectExited.AddListener(RemoveMagazine);
    }

    public void ShootHandGun()
    {
        _canShoot = _currentMagazine != null && _currentMagazine.bullets > 0 ? true : false; 
        
        if(_canShoot)
        {
            _currentMagazine.bullets--;
        }

        base.ShootWeapon();
    }

    public void AddMagazine(SelectEnterEventArgs args)
    {
        _currentMagazine = args.interactableObject.transform.gameObject.GetComponent<Magazine>();
        _currentMagazine.transform.SetParent(transform);
        ReloadWeapon();
    }

    public void RemoveMagazine(SelectExitEventArgs args)
    {
        _currentMagazine.transform.SetParent(null);
        _currentMagazine = null;
        ReloadWeapon();
    }
}
