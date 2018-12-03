using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int playerHealth; //Player's health
    public int numberofHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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

        if (playerHealth > numberofHearts) {
            playerHealth = numberofHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numberofHearts) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
        
        if (playerHealth <= 0) {
            //load game over scene
            SceneManager.LoadScene("GameOver");
        }

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
