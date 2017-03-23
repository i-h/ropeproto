using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour {
    public int Level = 1;
    public int XP = 0;
    public int HP = 0;
    public int MaxHP = 100;
    public int Attack = 10;
    public int Defence = 5;
    public float AttackRange = 1.0f;

    void Start()
    {
        HP = MaxHP;
    }

    public int TakeHit(CharacterAttributes attacker)
    {
        int damageTaken = 0;
        damageTaken = attacker.Attack - Defence;
        if(damageTaken < 0)
        {
            damageTaken = 0;
        }
        ApplyDamage(damageTaken);
        return damageTaken;
    }

    public void ApplyDamage(int amount)
    {
        HP -= amount; // Sama kuin: HP = HP - amount;
        if(HP <= 0)
        {
            // TODO: Die.
            Debug.Log(name + " IS DEAD!");
            gameObject.SetActive(false);
        }
    }
}
