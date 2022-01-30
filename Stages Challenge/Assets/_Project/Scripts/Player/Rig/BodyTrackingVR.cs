using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTrackingVR : MonoBehaviour
{
    [Tooltip("It represents the value for the player's height. ")]
    [Range(1.0f, 2.4f)]
    [SerializeField] private float _height;

    [SerializeField] private Transform _vrHead;
    [SerializeField]  private  Transform _vrLeftHand;
    [SerializeField] private Transform _vrRightHand;

    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;


    private Vector3 _headPositionY;
    private Quaternion _headRotationY;
    private Quaternion _bodyRotationY;

    void Update()
    {
        _headPositionY = _vrHead.transform.up;

        _headRotationY = Quaternion.Euler(0, _vrHead.rotation.eulerAngles.y, 0);
        _bodyRotationY = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        
        Vector3 center = (_vrHead.position + _vrLeftHand.position + _vrRightHand.position) / 3;

        if (Quaternion.Angle(_bodyRotationY, _headRotationY) > 75)
        {
                transform.rotation = Quaternion.Lerp(transform.rotation, _headRotationY * transform.rotation, 1);
        }

        // transform.position = center + _positionOffset;
    }
}
