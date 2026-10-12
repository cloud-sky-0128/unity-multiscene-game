using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricity : MonoBehaviour
{
    public int STtime = 2; // �T�O��STtime�]�m�@���q�{��
    private bool is_stop = false;
    private CapsuleCollider2D cc2d;
    private playeraction playeraction;
    public float oriMoveSpeed;
    public float oriJumpSpeed;
    private Game_SettingsManager settingsManager;

    void Start()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
        playeraction = GameObject.FindGameObjectWithTag("Player").GetComponent<playeraction>();
        oriMoveSpeed = playeraction.playerMoveSpeed;
        oriJumpSpeed = playeraction.playerJumpSpeed;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("electricity") && !is_stop)
        {
            is_stop = true;
            StartCoroutine(StopAndInvincible());
            AudioManager.instance.Play(2, "seBlock", false);
        }
    }

    IEnumerator StopAndInvincible()
    {
        playeraction.playerMoveSpeed = 0;
        playeraction.playerJumpSpeed = 0;
        // �Ȱ����a���
        yield return new WaitForSeconds(STtime);
        playeraction.playerMoveSpeed = oriMoveSpeed;
        playeraction.playerJumpSpeed = oriJumpSpeed;
        // �i�J�L�Įɶ�
        yield return new WaitForSeconds(1.5f);
        is_stop = false;
    }
}
