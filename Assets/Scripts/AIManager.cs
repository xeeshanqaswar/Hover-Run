using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public float factor = 100;
    public PathFollowAi[] AiObjects;

    [ContextMenu("Assign Values")]
    public void AssignValues()
    {
        for (int i = 0; i < AiObjects.Length; i++)
        {
            AiObjects[i].distanceTravelled = i * factor;
        }
    }


}
