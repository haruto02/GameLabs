using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        startTime = Time.time;
    }

    void Update() {
        if (Time.time - startTime > lifeTime) {
            Destroy(gameObject);
        }
    }
}
