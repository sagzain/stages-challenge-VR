using UnityEngine;

public class PlayerGear : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [Range(0.5f, 1f)]
    [SerializeField] private float _offsetY;
    [Range(0f, 1f)]
    [SerializeField] private float _offsetZ;

    void Update()
    {
        // Gear position under the head
        Vector3 height = _head.localPosition;
        height.z = Mathf.Lerp(0, height.z, _offsetZ);
        height.y = Mathf.Lerp(0, height.y, _offsetY);

        transform.localPosition = height;

        // Gear rotation
        Quaternion rotation = _head.localRotation;
        rotation.x = 0;
        rotation.z = 0;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, 1f);
    }
}
