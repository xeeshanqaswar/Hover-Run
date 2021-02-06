using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public GameObject[] panelRef;

    private GameDatabase _database;

    public static UIManager UM;

    private void Awake()
    {
        UM = this;
    }

    public void Init( GameDatabase database )
    {
        _database = database;
        EventManager.LevelComplete += OnLevelComplete;
        EventManager.GameCompleteEvent += OnGameComplete;
        EventManager.GameOverEvent += OnGameOver;
        EventManager.ScoreCountedEvent += ScoreCounter;

        scoreDisplay.text = string.Format("{0} / {1}", _database.currentScore, _database.RequiredScore);
    }

    public void Tick()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            panelRef[1].SetActive(false);
        }
    }

    public void OnGameBtnPress()
    {
        AudioManager.AM.PlaySFX(AudioManager.AM.buttonClip, 0.5f);

        EventManager.GameStartEventCall();
        panelRef[0].SetActive(false);

        if (_database.currentLevel == 0)
        {
            StartCoroutine(ShowObjective());
        }
    }

    IEnumerator ShowObjective()
    {
        yield return new WaitForSeconds(1f);
        panelRef[1].SetActive(true);
    }

    private void ScoreCounter()
    {
        scoreDisplay.text = string.Format("{0} / {1}", _database.currentScore, _database.RequiredScore);
    }

    public void OnReplayBtnPress()
    {
        _database.currentScore = 0;
        _database.currentLevel = 0;

        AudioManager.AM.PlaySFX(AudioManager.AM.buttonClip, 0.5f);
        LoadLevel("Gameplay");
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnGameRetryPress()
    {
        _database.currentScore = 0;

        AudioManager.AM.PlaySFX(AudioManager.AM.buttonClip, 0.5f);
        SceneManager.LoadScene("Gameplay");
    }

    private void OnGameOver() 
    {
        panelRef[3].SetActive(true);
        AudioManager.AM.StopMusic();
        AudioManager.AM.PlaySFX(AudioManager.AM.loseClip, 0.7f);
    }

    private void OnGameComplete()
    {
        panelRef[2].SetActive(true);
    }

    private void OnLevelComplete()
    {
        panelRef[4].SetActive(true);
    }

    private void OnDisable()
    {
        EventManager.LevelComplete -= OnLevelComplete;
        EventManager.GameCompleteEvent -= OnGameComplete;
        EventManager.GameOverEvent -= OnGameOver;
        EventManager.ScoreCountedEvent -= ScoreCounter;
    }

}
