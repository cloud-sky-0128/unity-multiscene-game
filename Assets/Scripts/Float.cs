using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float speed = 2f;
    public float waitTime = 0.5f;
    public Transform[] movePositions;

    private int currentIndex = 0;
    private float waitCounter;
    private bool shouldMove = false;

    void Start()
    {
        waitCounter = waitTime;
    }

    void Update()
    {
        if (shouldMove && movePositions.Length >= 2)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePositions[currentIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePositions[currentIndex].position) < 0.1f)
        {
            if (waitCounter <= 0)
            {
                currentIndex = (currentIndex + 1) % movePositions.Length;
                waitCounter = waitTime;
            }
            else
            {
                waitCounter -= Time.deltaTime;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null, true);
        }
    }
}
