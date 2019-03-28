using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D playerRB;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(moveInput * speed, playerRB.velocity.y);
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps > 0)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJumps == 0 && isGrounded == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
        }
    }
}
