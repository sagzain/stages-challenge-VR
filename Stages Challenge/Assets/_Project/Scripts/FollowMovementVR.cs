using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovementVR : MonoBehaviour
{
    [SerializeField] private Transform _vrHead;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;
    [SerializeField] private bool followPosition;
    [SerializeField] private bool followRotation;


    void Update()
    {
        if(followPosition) transform.position = _vrHead.TransformPoint(_positionOffset);
        if(followRotation) transform.rotation = _vrHead.rotation * Quaternion.Euler(_rotationOffset);
    }
}
