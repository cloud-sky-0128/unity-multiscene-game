using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraction : MonoBehaviour
{
    [Header("�t�׬���")]
    public float playerMoveSpeed; // ���a���ʳt��
    public float playerJumpSpeed; // ���a���D�t��

    [Header("���D����")]
    public float playerJumpCount = 2; // ���a���D����

    [Header("�P�_����")]
    public bool isGround; // �O�_�b�a���W
    public bool pressedJump; // �O�_���U���D��

    [Header("��L�ե�")]
    public Transform foot; // �Ω��˴��a�����}����m
    public LayerMask Ground; // �Ω�P�_���Ǫ���O�a��
    public Rigidbody2D playerRB; // ���a���⪺����ե�
    public Collider2D playerColl; // ���a���⪺�I�����ե�
    public Animator playerAnim; // ���a���⪺�ʵe����ե�
    private Game_SettingsManager settingsManager;


    void Start()
    {
        // ������a���I�����ե�
        playerColl = GetComponent<Collider2D>();
        // ������a������ե�
        playerRB = GetComponent<Rigidbody2D>();
        // ������a���ʵe����ե�
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // ��s���A�ˬd
        UpdateCheck();
        // �����ʵe���A
        AnimSwitch();
    }

    void FixedUpdate()
    {
        // �T�w��s�ˬd
        FixedupdateCheck();
        // ����a����
        playerMove();
        // ����a���D
        playerJump();
    }

    // ����a���ʪ���k
    void playerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal"); // ���������J
        float faceNum = Input.GetAxisRaw("Horizontal"); // �����l������J�A�Ω�½�ਤ��
        playerRB.velocity = new Vector2(playerMoveSpeed * horizontalNum, playerRB.velocity.y); // �]�w���⪺�����t��
        playerAnim.SetFloat("run", Mathf.Abs(playerMoveSpeed * horizontalNum)); // �]�w�B��ʵe�Ѽ�

        // �p�G������J�����s�A½�ਤ�⪺�¦V
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(faceNum, transform.localScale.y, transform.localScale.z);
        }
    }

    // ����a���D����k
    void playerJump()
    {
        // �p�G���b�a���B���D���Ƥ֩�1�A�h������D
        if (!isGround && playerJumpCount < 1)
        {
            pressedJump = false;
        }

        // �p�G���U���D��B�b�a���W�A������D
        if (pressedJump && isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // �]�w���⪺�����t��
            playerJumpCount = 1; // ���m���D����
            AudioManager.instance.Play(4, "seJump", false);
        }
        // �p�G���U���D��B���Ѿl���D���ƥB���b�a���W�A��������
        else if (pressedJump && playerJumpCount > 0 && !isGround)
        {
            pressedJump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerJumpSpeed); // �]�w���⪺�����t��
            playerJumpCount--; // ��ָ��D����
            AudioManager.instance.Play(4, "seJump", false);
        }
    }

    // �T�w��s�ˬd��k�A�Ω��˴��O�_�b�a���W
    void FixedupdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground); // �ϥέ��|���˴��}����m�O�_��Ĳ�a��
    }

    // ��s�ˬd��k�A�Ω��˴����D��O�_�Q���U
    void UpdateCheck()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pressedJump = true;
        }
    }

    // �����ʵe���A����k
    void AnimSwitch()
    {
        // �p�G�b�a���W�A�]�w���D�ʵe�ѼƬ� false
        if (isGround)
        {
            playerAnim.SetBool("jump", false);
        }
        // �p�G���b�a���B�����t�פ����s�A�]�w���D�ʵe�ѼƬ� true
        if (!isGround && playerRB.velocity.y != 0)
        {
            playerAnim.SetBool("jump", true);
        }
    }
}
