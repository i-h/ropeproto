using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory ActiveInventory;
    [SerializeField]
    private List<Transform> _storage = new List<Transform>();
    private int _money = 0;
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
        _storage.Add(itm);
        itm.gameObject.SetActive(false);
        itm.SetParent(transform);
    }
    public Transform RemoveTopItem()
    {
        return RemoveItemAt(_storage.Count - 1);
       
    }
    public Transform RemoveItemAt(int index)
    {
        if (index < 0 || index >= _storage.Count)
        {
            return null;
        }
        Transform itm = _storage[index];
        _storage.RemoveAt(index);

        itm.gameObject.SetActive(true);
        itm.SetParent(null);
        itm.position = transform.position + transform.forward;

        return itm;
    }

    public void SellItem(ForSale itm)
    {
        _money += itm.Value;
        _storage.Remove(itm.transform);
        Destroy(itm.gameObject);
    }

    private void OnGUI()
    {
        /*if(GUILayout.Button("Remove last item"))
        {
            RemoveTopItem();
        }*/

        GUILayout.Label("Money: " + _money);

        for (int i = 0; i < _storage.Count; i++)
        {
            Transform item_t = _storage[i];
            GUILayout.BeginHorizontal();
            GUILayout.Label(item_t.name);
            if (GUILayout.Button("Drop"))
            {
                RemoveItemAt(i);
            }

            ForSale itm_sale = item_t.GetComponent<ForSale>();
            if (itm_sale && GUILayout.Button("Sell"))
            {
                SellItem(itm_sale);
            }
            GUILayout.EndHorizontal();
        }
    }
}
