using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {
    public bool DestroyOnOpen = true;
    public float LaunchSpeed = 4.0f;
    [SerializeField]
    public List<ChestItem> Contents = new List<ChestItem>();

    Vector3 _launchVector = new Vector3();

    void OnMouseDown()
    {
        foreach(ChestItem itm in Contents)
        {
            for(int i = 0; i < itm.Count; i++)
            {
                Transform itm_obj = Instantiate<Transform>(itm.Item);
                itm_obj.position = transform.position + Random.insideUnitSphere + Vector3.up;
                itm_obj.rotation = Random.rotation;

                Rigidbody itm_rb = itm_obj.GetComponent<Rigidbody>();
                if (!itm_rb)
                {
                    itm_obj.gameObject.AddComponent<Rigidbody>();
                }

                _launchVector.x = Random.value;
                _launchVector.z = Random.value;
                _launchVector.y = LaunchSpeed;

                itm_rb.velocity = _launchVector;
                itm_rb.angularVelocity = Random.insideUnitSphere;
            }
        }
        if (DestroyOnOpen)
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public struct ChestItem
    {
        public Transform Item;
        public int Count;
    }
}
