using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findTeacher : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float activeTime = 5.0f;  // �Ѯv���d�ɶ�
    public float inactiveTime = 2.0f;
    private PlayerScore playerScore;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2d;
    private bool is_catch = false;

    void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        StartCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while (true)
        {
            spriteRenderer.enabled = false;
            collider2d.enabled = false;

            yield return new WaitForSeconds(inactiveTime);

            int randomIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[randomIndex].position;

            spriteRenderer.enabled = true;
            collider2d.enabled = true;

            yield return new WaitForSeconds(activeTime);
            is_catch = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerScore != null)
        {
            if (!is_catch)
            {
                playerScore.IncreaseScore(10);
                AudioManager.instance.Play(1, "seBubble", false);
                is_catch = true;
            }
        }
    }
}
