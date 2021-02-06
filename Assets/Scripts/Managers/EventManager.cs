using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventManager
{
    public static event Action GameStartEvent;   
    public static void GameStartEventCall()
    {
        GameStartEvent.Invoke();
    }

    public static event Action GameOverEvent;
    public static void GameOverEventCall()
    {
        GameOverEvent.Invoke();
    }

    public static event Action ScoreCountedEvent;
    public static void ScoreCountedEventCall()
    {
        ScoreCountedEvent.Invoke();
    }

    public static event Action GameCompleteEvent;
    public static void GameCompleteEventCall()
    {
        GameCompleteEvent.Invoke();
    }

    public static event Action LevelComplete;
    public static void LevelCompleteEventCall()
    {
        LevelComplete.Invoke();
    }

}
