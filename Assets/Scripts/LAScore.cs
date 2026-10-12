using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAScore : MonoBehaviour
{
    public static LAScore instance;
    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }
}