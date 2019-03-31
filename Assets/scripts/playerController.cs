using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D playerRB;
    public  GameObject player;
    public static float altura;
    public Animator anim;
    public static bool isGrounded;
    public LayerMask whatIsGround;
    private Collider2D groundCheck;
    public static bool isAlive;
    public bool alive;
    private int extraJumps;
    public int extraJumpsValue;
  //  private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {

        isAlive = player.transform.position.y > -4.5f;
        extraJumps = extraJumpsValue;
        //anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isAlive = player.transform.position.y > -4.5f;
        if(isAlive){
            isGrounded = Physics2D.IsTouchingLayers(groundCheck, whatIsGround);
            moveInput = Input.GetAxis("Horizontal");
            playerRB.velocity = new Vector2(moveInput * speed, playerRB.velocity.y);
        }
    }

    void Update()
    {
         isAlive = player.transform.position.y > -4.5f;
         alive = isAlive;
         if(isAlive){
         altura = player.transform.position.y;
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
    }
       
    }
}
