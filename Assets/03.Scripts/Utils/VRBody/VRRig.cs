﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap {
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map() {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour {
    [Range(0, 1)] public float turnSmoothness = 1;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;
    public Transform headConstraint;
    private Vector3 headBodyOffest;

    private void Start() {
        headBodyOffest = transform.position - headConstraint.position;
    }

    private void FixedUpdate() {
        transform.position = headConstraint.position + headBodyOffest;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, turnSmoothness);
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
