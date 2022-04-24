using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemData Item;

    void Pickup()
    {
        InvManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
    Debug.Log("touched!");
    Pickup();
    }
}
