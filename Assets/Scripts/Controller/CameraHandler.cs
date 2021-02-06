using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public float lerpSpeed;
    public float rotLerpSpeed = 4f;
    public Transform camFollow;

    private bool gameStart;

    private void OnEnable()
    {
        EventManager.GameStartEvent += GameStartEvent;
    }

    private void GameStartEvent()
    {
        gameStart = true;
    }

    public void FixedTick()
    {
        if (gameStart)
        {
            transform.position = Vector3.Lerp(transform.position, camFollow.position, lerpSpeed * Time.deltaTime);
            Quaternion newRotation = Quaternion.LookRotation(camFollow.forward, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation , newRotation, rotLerpSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        EventManager.GameStartEvent += GameStartEvent;
    }

}
