using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // if (other.tag == "Player" || other.tag == "Bullet") {
        //     Destroy(other.gameObject);
        //     Destroy(gameObject);
        // }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
