using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotorAudio : MonoBehaviour
{

    private AudioSource audioSource;
    private const float pitchControlFactor = 0.1f;
    public  float minPitch = 0.1f;
    public  float maxPitch = 2.0f;

    private Vector3 myVelocity;
    private Rigidbody carRigidbody;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        myVelocity = carRigidbody.velocity;
        float forwardSpeed = Mathf.Abs( transform.InverseTransformDirection(myVelocity).z );
        float controlledPitch = forwardSpeed * pitchControlFactor;
        audioSource.pitch = Mathf.Clamp(controlledPitch, minPitch, maxPitch);    
    }

}
