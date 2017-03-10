using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {
    public float MoveSpeed = 10.0f;
    Vector3 _moveVector = new Vector3();
    Rigidbody _rb;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");

        _rb.MovePosition(transform.position + _moveVector.normalized * Time.deltaTime * MoveSpeed);

    }
}
