using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTodoor : MonoBehaviour
{
    public Transform otherdoor;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        playerTransform.position = otherdoor.position;
    }
}
