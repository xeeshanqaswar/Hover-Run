using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameDatabase database;


    private LevelManager _levelManager;
    private UIManager _UiManager;

    public static GameManager GM;

    private void Awake()
    {
        GM = this;
    }

    private void Start()
    {
        _levelManager = LevelManager.LM;
        _levelManager.Init(database);

        _UiManager = UIManager.UM;
        _UiManager.Init(database);

        AudioManager.AM.PlayMusic(AudioManager.AM.levelAmbience);
    }

    private void Update()
    {
        _UiManager.Tick();
    }

}
