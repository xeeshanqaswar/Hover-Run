using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Player Profile" , menuName = "Custom Data / Profile")]
public class GameDatabase : ScriptableObject
{
    [Header("== LEVEL PROPERTIES ==")]
    public int currentScore;
    public LevelUnit[] levelProperties;
    
    [Header("== PROGRESSION ==")]
    public int currentLevel;
    public int maxLevel;
    public int lifeCount;

    public int RequiredScore
    {
        get { return levelProperties[currentLevel].targetScore; }
    }

}

[Serializable]
public class LevelUnit
{
    public string name = "Level";
    public int targetScore;
}