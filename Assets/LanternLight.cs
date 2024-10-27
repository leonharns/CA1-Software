using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLight : MonoBehaviour
{
    [SerializeField] Light lanternStrength;
    public float maxFuel = 100f;
    public float currentFuel;

    public float fuelConsumptionRate = 1f;

    public float minIntensity = 0f;
    public float maxIntensity = 25f;

    void Start()
    {
        currentFuel = maxFuel;

        if (lanternStrength != null)
            lanternStrength.intensity = maxIntensity;
    }

    void Update()
    {
        if (currentFuel > 0)
        {
            currentFuel -= fuelConsumptionRate * Time.deltaTime;
            currentFuel = Mathf.Max(currentFuel, 0); 
            float fuelPercentage = currentFuel / maxFuel;
            lanternStrength.intensity = Mathf.Lerp(minIntensity, maxIntensity, fuelPercentage);
        }
    }

    public void AddFuel(float amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Min(currentFuel, maxFuel);
    }
}
