using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float reducedSpeed;
    public float reducedjump;
    public GameObject player;
    private float originalSpeed;
    private float originaljump;
    private playeraction playeraction;
    private coffee coffee;

    void Start()
    {
        playeraction = player.GetComponent<playeraction>();
        coffee = player.GetComponent<coffee>();
        originalSpeed = playeraction.playerMoveSpeed;
        originaljump = playeraction.playerJumpSpeed;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playeraction.playerMoveSpeed != coffee.fastSpeed && playeraction.playerMoveSpeed != reducedSpeed)
        {
            if (playeraction != null)
            {
                playeraction.playerMoveSpeed = reducedSpeed;
                playeraction.playerJumpSpeed = reducedjump;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && playeraction.playerMoveSpeed != coffee.fastSpeed)
        {
            if (playeraction != null )
            {
                playeraction.playerMoveSpeed = originalSpeed;
                playeraction.playerJumpSpeed = originaljump;
            }
        }
    }
}
