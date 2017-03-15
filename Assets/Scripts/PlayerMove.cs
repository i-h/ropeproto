using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {
    public float MoveSpeed = 10.0f;
    Vector3 _moveVector = new Vector3();
    Vector3 _mouseDir = new Vector3();
    Rigidbody _rb;
	// Use this for initialization
	void Start () {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
        _moveVector.x = Input.GetAxisRaw("Horizontal");
        _moveVector.z = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(1))
        {
            _mouseDir.x = Input.mousePosition.x - Screen.width / 2;
            _mouseDir.y = Input.mousePosition.y - Screen.height / 2;
            _moveVector.x = _mouseDir.normalized.x;
            _moveVector.z = _mouseDir.normalized.y;
        }

        Move(_moveVector);
    }

    void OnGUI()
    {
        //GUILayout.Label("Mouse Position: "+_mouseDir);
    }

    void Move(Vector3 dir)
    {
        dir = Vector3.ClampMagnitude(dir, 1.0f);
        _rb.MovePosition(transform.position + dir * Time.deltaTime * MoveSpeed);
    }
}
