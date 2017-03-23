using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAttributes))]
public class Enemy : MonoBehaviour {
    CharacterAttributes _attr;
	// Use this for initialization
	void Start () {
        _attr = GetComponent<CharacterAttributes>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {

    }
}
