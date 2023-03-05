using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * speed;
    }
}
