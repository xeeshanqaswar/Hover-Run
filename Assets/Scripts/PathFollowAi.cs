using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollowAi : MonoBehaviour
{

    public PathCreator pathCreator;
    public float speed = 5f;
    public float distanceTravelled = 0f;

    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }

}
