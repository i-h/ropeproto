﻿using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
    public bool damaging = false;
    public int damage = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    int GetDamage()
    {
        return damage + damage / 5 * Player.GetAttr().Level-1;
    }
    void OnCollisionEnter(Collision c)
    {
        if (damaging)
        {
            if (c.gameObject.CompareTag("Enemy"))
            {
                c.gameObject.GetComponent<Enemy>().TakeDamage(GetDamage());
            }
        }
    }
    public void Attack()
    {
        GetComponent<Animation>().Play("swing");
    }
}