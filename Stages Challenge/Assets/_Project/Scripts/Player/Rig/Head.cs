using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform _headConstraint;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private Vector3 _rotationOffset;
    private Vector3 _headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        _headBodyOffset = _headConstraint.position - _followTarget.position;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _headConstraint.position + _headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(_headConstraint.up,  Vector3.up).normalized;

        _headConstraint.position = _followTarget.TransformPoint(_positionOffset);
        _headConstraint.rotation = _followTarget.rotation * Quaternion.Euler(_rotationOffset);
    }
}
