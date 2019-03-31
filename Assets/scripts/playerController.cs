using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D playerRB;
    public Animator anim;
    private bool isGrounded;
    public LayerMask whatIsGround;
    private Collider2D groundCheck;

    private int extraJumps;
    public int extraJumpsValue;
  //  private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        //anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(groundCheck, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        playerRB.velocity = new Vector2(moveInput * speed, playerRB.velocity.y);
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            anim.SetBool("grounded", true);
        }else{
            anim.SetBool("grounded",false);
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
            //isAlive = playerRB.transform.position.y > 4.5f;
            
            //anim.SetBool("alive",isAlive);
    }
}
