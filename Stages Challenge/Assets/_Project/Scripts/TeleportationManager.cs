using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _teleportActivate;
    [SerializeField] private InputActionReference _teleportCancel;

    // Start is called before the first frame update
    void OnEnable()
    {
        _teleportActivate.ToInputAction().performed += OnTeleportActivate;
        _teleportCancel.ToInputAction().performed += OnTeleportCancel;
    }

    void OnTeleportActivate(InputAction.CallbackContext context)
    {

    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {

    }
}
