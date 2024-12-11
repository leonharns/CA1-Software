using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIntroController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject FakeCar;
    public GameObject RealCar;
    public GameObject Player;
    public AudioClip brokenDown;
    void Start()
    {
        StartCoroutine(SwitchCars());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     IEnumerator SwitchCars()
    {
        yield return new WaitForSeconds(4F);
        FakeCar.SetActive(false);
        RealCar.SetActive(true);
        Player.SetActive(true);
    }
}
