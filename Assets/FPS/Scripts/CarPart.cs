using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Unity.FPS.Game
{
    public class CarPart : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == 3)
            {
                other.gameObject.GetComponent<EscapeTrigger>().CollectCarPart();
                Destroy(gameObject);
            }
        }
    }
}

