using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    float steerSpeed = 300f;
    float carSpeed = 20f;

    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boost = 30f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * carSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        carSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost"){
            carSpeed = boost;
        }
    }
}