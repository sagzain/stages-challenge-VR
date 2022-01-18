using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class PlayerRigVR : MonoBehaviour
{
    [SerializeField] private VRMap head;
    [SerializeField] private VRMap leftHand;
    [SerializeField] private VRMap rightHand;

    [SerializeField] private Transform _headConstraint; 
    private Vector3 _headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        _headBodyOffset = transform.position - _headConstraint.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _headConstraint.position + _headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(_headConstraint.up, Vector3.up).normalized;

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
