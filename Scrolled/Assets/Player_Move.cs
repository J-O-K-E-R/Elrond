using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move: MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = true;
	public int playerJumpP = 1250;
	public float moveX;
    public Vector2 move;
    public int jumpcount = 2;
    public bool isfalling = false;
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
        move = rb.velocity;

        if(jumpcount > 0) {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
                jumpcount--;
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

        if (move.y < 0) // if the player has started falling, reset their jumps once they hit the ground
        {
            isfalling = true;
        }
        if (isfalling) 
        {
            if (move.y == 0)
            {
                jumpcount = 2;
                isfalling = false;
            }
        }
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
