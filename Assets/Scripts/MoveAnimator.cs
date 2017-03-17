using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMove))]
public class MoveAnimator : MonoBehaviour {
    Animator _anim;
    Rigidbody _rb;
    PlayerMove _pm;
    Vector3 _moveVector = new Vector3();

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _pm = GetComponent<PlayerMove>();
    }

	void Update () {
        _moveVector = _pm.GetMoveVector();
        _anim.SetFloat("MoveSpeed", _moveVector.magnitude);
	}
}
