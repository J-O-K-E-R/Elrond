using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move: MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = true;
	public int playerJumpP = 1250;
	private float moveX;
    bool isgrounded = true;
    private Rigidbody2D rb;
    // Use this for initialization

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		PlayerMove();
        

    }
    void PlayerMove() {
		//Controls
		moveX = Input.GetAxis("Horizontal");

        if(isgrounded == true) {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
		//Animations

		//PlayerDirection
		if(moveX < 0.0f && facingRight == false){
			FlipPlayer();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer();
		}
        //Physics
        rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
    }

    void Jump() {
        //Jumping Code
        rb.AddForce(Vector2.up * playerJumpP, ForceMode2D.Force);
    }
	void FlipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
	}
}
