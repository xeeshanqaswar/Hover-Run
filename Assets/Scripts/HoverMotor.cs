using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour
{

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private Vector3 movDirection;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        movDirection = new Vector3(turnInput, 0f, powerInput).normalized;
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float propotinalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedForce = Vector3.up * propotinalHeight * hoverForce;
            carRigidbody.AddForce(appliedForce, ForceMode.Acceleration);
        }

        if (movDirection.magnitude > 0.05f)
        {
            carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
            carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }

    }

}
