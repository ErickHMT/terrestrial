using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float speed = .05f;
    public float turnSpeed = 8f;

    Vector3 movement;
    Quaternion rotation = Quaternion.identity;
    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement.Set(horizontal, 0f, vertical);
        movement.Normalize();

        Vector3 desiredFoward = Vector3.RotateTowards(
            transform.forward, 
            movement, 
            turnSpeed * Time.deltaTime, 0f);

        rotation = Quaternion.LookRotation(desiredFoward);

        rb.MovePosition(rb.position + movement * speed);
        // rb.MoveRotation(rotation);
    }
}
