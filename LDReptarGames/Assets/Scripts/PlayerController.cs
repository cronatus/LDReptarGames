using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int playerHealth; //Player's health

    public float speed; // The base speed of the player

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start() {

        rb = GetComponent<Rigidbody2D>();   

    }

    void Update() {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // Detect directional input from either WASD or the ARROW KEYS to determine the intended movemenet of the player
        moveVelocity = moveInput.normalized * speed; // Move the player according to the input above

    }

    void FixedUpdate() {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
}
