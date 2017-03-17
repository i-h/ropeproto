using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform FollowTarget;
    public float FollowSpeed = 10.0f;
    Vector3 _offset;
    Vector3 _targetPosition;
    Vector3 _targetDirection;

	// Use this for initialization
	void Start () {
        _offset = transform.position - FollowTarget.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        _targetPosition = FollowTarget.position + _offset;
        _targetDirection = transform.position - _targetPosition;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _targetDirection.magnitude*FollowSpeed+0.1f);
	}
}
