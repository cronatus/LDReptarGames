using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    //camera to follow player
    //public Transform player;
    //public Vector3 offset;

    void Start() {

        rb = GetComponent<Rigidbody2D>();   

    }

    void Update() {
        //the camera will follow the player but it will follow the player in a certain offset position
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

    }

    void FixedUpdate() {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }

}
