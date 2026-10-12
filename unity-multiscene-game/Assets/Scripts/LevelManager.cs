using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelNumber;
    public PlayerScore playerScore;

    public void EndLevel()
    {
        ScoreManager.Instance.SetLevelScore(levelNumber, playerScore.score);
    }
}
