using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float tilt = 4.0f;
    public Boundary bound;

    public GameObject bullet;
    public Transform bulletSp;

    public float fireRate;
    private float timeRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time > timeRate)
        {
            timeRate = Time.time + fireRate;
            Instantiate(bullet,bulletSp.position, bulletSp.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    
    void FixedUpdate()
    {
        var hoz = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3 (hoz, 1, ver)*speed;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x,bound.xMin,bound.xMax),
            1,
            Mathf.Clamp(transform.position.z,bound.zMin,bound.zMax));

        transform.rotation = Quaternion.Euler(new Vector3(0,0,GetComponent<Rigidbody>().velocity.x * -tilt));
    }
}
