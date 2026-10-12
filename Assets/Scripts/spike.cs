using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public int damage;
    private PlayerScore PlayerScore;
    void Start()
    {
        PlayerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            PlayerScore.DamegePlayer(damage);
        }
    }
}
