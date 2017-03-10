using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory ActiveInventory;
    Stack<Transform> _storage = new Stack<Transform>();
	// Use this for initialization
	void Start () {
        ActiveInventory = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            RemoveTopItem();
        }
	}

    public void CollectItem(Transform itm)
    {
        _storage.Push(itm);
        itm.gameObject.SetActive(false);
        itm.SetParent(transform);
    }
    public void RemoveTopItem()
    {
        if (_storage.Count <= 0)
        {
            return;
        }
        Transform itm = _storage.Pop();
        itm.gameObject.SetActive(true);
        itm.SetParent(null);
        itm.position = transform.position + transform.forward;
    }
}
