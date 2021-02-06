using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour
{

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private bool canPlay = true;

    private Vector3 movDirection;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;
    private GameDatabase _database;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    public void Init()
    {
        _database = GameManager.GM.database;
        EventManager.GameOverEvent += OnGameOver;
    }

    public void Tick()
    {
        if (canPlay)
        {
            powerInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");
        }

        movDirection = new Vector3(turnInput, 0f, powerInput).normalized;
    }

    public void FixedTick()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float propotinalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedForce = Vector3.up * propotinalHeight * hoverForce;
            carRigidbody.AddForce(appliedForce, ForceMode.Acceleration);
        }

        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        //carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.fixedDeltaTime);

    }

    private void OnGameOver()
    {
        canPlay = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("UnTouchable"))
        {
            EventManager.GameOverEventCall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        if (other.CompareTag("ScoreRing"))
        {
            AudioManager.AM.PlaySFX(AudioManager.AM.ringClip, 0.5f);

            EventManager.ScoreCountedEventCall(); 
            obj.GetComponent<Collider>().enabled = false;
            StartCoroutine(DestroyRing(obj.transform.parent.gameObject, 0.5f));
        }
        else if (other.CompareTag("EndRing"))
        {
            AudioManager.AM.PlaySFX(AudioManager.AM.ringClip, 0.5f);

            EventManager.LevelCompleteEventCall();
            obj.GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator DestroyRing(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.GameOverEvent -= OnGameOver;
    }

}
