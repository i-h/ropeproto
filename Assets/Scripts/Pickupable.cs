using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {
    public bool PickupByCollision = true;
    private bool _collisionPickupEnabled = false;
    private float _pickupDelay = 2.0f;

    void OnEnable()
    {
        _collisionPickupEnabled = false;
        if (PickupByCollision)
        {
            Invoke("ActivateCollisionPickup", _pickupDelay);
        }
    }
    private void OnMouseDown()
    {
        Inventory.ActiveInventory.CollectItem(transform);
    }
    private void OnCollisionEnter(Collision c)
    {
        if (_collisionPickupEnabled && c.collider.CompareTag("Player"))
        {
            Inventory.ActiveInventory.CollectItem(transform);
        }        
    }
    private void ActivateCollisionPickup()
    {
        _collisionPickupEnabled = true;
    }
}
