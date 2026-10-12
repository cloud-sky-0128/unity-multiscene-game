using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f; // 跳跃力量
    public Transform groundCheck; // 用于检测玩家是否在地面上的空物体
    public LayerMask groundLayer; // 地面的Layer
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 检测玩家是否在地面上
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 获取玩家的移动输入
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;

        // 在空中时，按下空格键触发跳跃
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // 移动玩家
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
