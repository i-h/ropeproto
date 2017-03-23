using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAttributes))]
public class Player : MonoBehaviour {
    static GameObject _plrObj;
    static CharacterAttributes _plrAttr;
	// Use this for initialization
	void Start () {
        _plrObj = gameObject;
        _plrAttr = GetComponent<CharacterAttributes>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {

    }

    public static Transform GetTransform()
    {
        return _plrObj.transform;
    }
    public static CharacterAttributes GetAttr()
    {
        return _plrAttr;
    }
}
