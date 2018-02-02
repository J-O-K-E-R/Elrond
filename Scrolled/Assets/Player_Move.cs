using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move: MonoBehaviour {

	public float playerSpeed = 5;
    public float jumpSpeed = 10;
    public float maxSpeed = 10;
    private bool facingRight = false;

    public bool isTouchingGround;
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.520512f;
    public LayerMask groundLayer;

    public int jumpcount = 1;
    private Rigidbody2D rb2d;
    private Animator anim;

    public Vector3 respawnPoint;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheckPoint = transform.Find("GroundCheckPoint");
        groundLayer = 1 << 8;
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform.position;
    }

    // Update is called once per frame
    void Update () {
        
    }

    void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        PlayerMove();
    }
    void PlayerMove() {

        float movement = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(movement));
        anim.SetBool("OnGround", isTouchingGround);

        if (rb2d.velocity.magnitude > maxSpeed) {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
        
        if (movement > 0f) {
            rb2d.velocity = new Vector2(movement * playerSpeed, rb2d.velocity.y);
        }
        else if (movement < 0f) {
            rb2d.velocity = new Vector2(movement * playerSpeed, rb2d.velocity.y);
        }
        else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetButtonDown("Jump")&& isTouchingGround) { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            jumpcount--;
        }
        if (Input.GetButtonDown("Jump") && !isTouchingGround) {
            if (jumpcount >= 1) {
                jumpcount--;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
        }
        if (isTouchingGround) {
            Debug.Log("");
            jumpcount = 1;
        }


        if (movement > 0 && !facingRight)
            FlipPlayer();
        else if (movement < 0 && facingRight)
            FlipPlayer();
    }
    void FlipPlayer() {
           facingRight = !facingRight;
           Vector2 localScale = gameObject.transform.localScale;
           localScale.x *= -1;
           transform.localScale = localScale;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "FallDetector") {
            //what will happen when player enters fall detector zone
            transform.position = respawnPoint;
        }
    }
}
