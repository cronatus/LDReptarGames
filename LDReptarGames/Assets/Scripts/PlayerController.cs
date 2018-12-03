using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int playerHealth; //Player's health

    public float speed; // The base speed of the player

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveVelocity;

    void Start() {

        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Detect directional input from either WASD or the ARROW KEYS to determine the intended movemenet of the player
        moveVelocity = moveInput.normalized * speed; // Move the player according to the input above
        Debug.Log(moveVelocity);
        
        

    }

    void FixedUpdate() {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        if (moveVelocity.y == 0.0 && moveVelocity.x == 0) {

            anim.SetBool("idle", true);
            anim.SetBool("running", false);

        } else if ((moveVelocity.y > 0.1 || moveVelocity.x > 0.1) || (moveVelocity.y < -0.1 || moveVelocity.x < -0.1)) {

            anim.SetBool("running", true);
            anim.SetBool("idle", false);

        }

    }
}
