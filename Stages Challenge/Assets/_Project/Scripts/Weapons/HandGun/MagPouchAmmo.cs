using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagPouchAmmo : MonoBehaviour
{
    [SerializeField] private GameObject _ammoPrefab;
    
    private GameObject _currentInstance;
    private XRSocketInteractor _socket;

    void Start()
    {
        _socket = GetComponent<XRSocketInteractor>();
        _currentInstance = Instantiate(_ammoPrefab, _socket.attachTransform);
        _socket.startingSelectedInteractable = _currentInstance.GetComponent<XRBaseInteractable>();
    }

    void Update()
    {
        if(!_socket.hasSelection)
        {
            _currentInstance.transform.SetParent(null);
            _currentInstance = null;
            _currentInstance = Instantiate(_ammoPrefab, _socket.attachTransform);
        }
    }
}
