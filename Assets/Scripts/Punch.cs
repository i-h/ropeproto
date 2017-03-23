using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAttributes))]
public class Punch : MonoBehaviour {
    public KeyCode AttackKey = KeyCode.Mouse0;  // Hyökkäyspainike
    public float AttackInterval = 1.0f;         // Hyökkäysten väli sekunneissa
    float _lastAttack = -1.0f;
    CharacterAttributes _myAttributes;          
    bool _isPlayer = false;

	// Use this for initialization
	void Start () {
        _myAttributes = GetComponent<CharacterAttributes>();
        _isPlayer = transform.CompareTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * 
         * */         
         
        if(_isPlayer && Input.GetKeyDown(AttackKey))
        {
            Attack();
        }

        /* If the attached character is not the player,
         * attack every AttackInterval seconds.
         * */
        if (!_isPlayer)
        {
            if(Time.time - _lastAttack > AttackInterval)
            {
                Attack();
            }
        }


	}

    void Attack()
    {
        _lastAttack = Time.time;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _myAttributes.AttackRange))
        {
            CharacterAttributes defenderAttr = hit.transform.GetComponent<CharacterAttributes>();
            if (defenderAttr)
            {
                defenderAttr.TakeHit(_myAttributes);
            }
        }
    }
}
