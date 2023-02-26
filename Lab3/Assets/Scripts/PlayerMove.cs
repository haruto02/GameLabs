using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float tiltAngle;
    public Boundary bound;

    private Rigidbody rb;

    public GameObject bullet;
    public Transform bulletSpawn;

    public float fireRate;
    public float timeRate;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetButton("Fire1") && Time.time > timeRate) {
            timeRate = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }

    void FixedUpdate()
    {   
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * speed;

        // Clamp the ship's position to stay within the game area
        Vector3 clampedPosition = rb.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bound.xMin, bound.xMax);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, bound.zMin, bound.zMax);
        rb.position = clampedPosition;

        // Add rotation to the ship based on its velocity
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -moveHorizontal * tiltAngle);
        rb.rotation = targetRotation;
    }
}
