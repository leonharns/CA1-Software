using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public float fuelAmount = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.gameObject.GetComponentInChildren<LanternLight>().AddFuel(fuelAmount);
            Debug.Log("coll fuel");
            Destroy(gameObject);
        }
    }
}