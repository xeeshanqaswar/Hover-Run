using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region FIELD DECLERATION

    HoverMotor _hoverMotor;
    HoverMotorAudio _motorAudio;
    CameraHandler _camManager;

    #endregion

    private void Awake()
    {
        _hoverMotor = GetComponent<HoverMotor>();
        _hoverMotor.Init();

        _motorAudio = GetComponent<HoverMotorAudio>();
        _camManager = Camera.main.transform.parent.GetComponent<CameraHandler>();
    }

    void Update()
    {
        _hoverMotor.Tick();
    }

    private void FixedUpdate()
    {
        _camManager.FixedTick();
        _motorAudio.FixedTick();
        _hoverMotor.FixedTick();
    }


}
