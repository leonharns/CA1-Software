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
    public AudioSource AS;
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
        yield return new WaitForSeconds(1.5F);
        AS.PlayOneShot(brokenDown);
        yield return new WaitForSeconds(2.5F);
        FakeCar.SetActive(false);
        RealCar.SetActive(true);
        Player.SetActive(true);
    }
}
