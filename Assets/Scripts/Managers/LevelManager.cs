using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public GameObject[] levelObjects;
    public GameObject endRing;

    public static LevelManager LM;

    private GameDatabase _database;

    private void Awake()
    {
        LM = this;
    }

    public void Init(GameDatabase database)
    {
        _database = database;

        EventManager.LevelComplete += OnLevelCompltete;
        EventManager.GameStartEvent += OnGameStart;
        EventManager.ScoreCountedEvent += OnNewScoreAdded;
    }

    public void OnGameStart()
    {
        for (int i = 0; i < levelObjects.Length; i++)
        {
            levelObjects[i].SetActive(i == _database.currentLevel);
        }
    }

    private void OnNewScoreAdded()
    {
        _database.currentScore++;
        endRing.SetActive(_database.currentScore == _database.RequiredScore);
    }

    public void OnLevelCompltete()
    {
        if (_database.currentLevel < _database.maxLevel)
        {
            _database.currentLevel++;
            _database.currentScore = 0;
        }
        else
        {
            _database.currentScore = 0;
            EventManager.GameCompleteEventCall();
        }

    }

    private void OnDisable()
    {
        EventManager.LevelComplete -= OnLevelCompltete;
        EventManager.GameStartEvent -= OnGameStart;
        EventManager.ScoreCountedEvent -= OnNewScoreAdded;
    }

}
