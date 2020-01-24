using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannonBall : MonoBehaviour
{
    public GameObject cannonBall;
    public float speed = 100f;
    public Transform barrelLocation;

    float delay = 4f;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0f){
            GameObject instBall;
            instBall = Instantiate(cannonBall, barrelLocation.position, barrelLocation.rotation);
            instBall.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * speed);
            Destroy(instBall, 10f);
            delay = 4f;
        }
    }
}
