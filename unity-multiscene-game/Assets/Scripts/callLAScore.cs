using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callLAScore : MonoBehaviour
{
    private PlayerScore playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        playerScore.score = LAScore.instance.GetScore();
        playerScore.UpdateScoreText();
    }
}
