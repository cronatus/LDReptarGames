using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour {

    public float speed;     // The base speed of the enemy.
    private Transform playerPos;    // The position of the player in the game world.

    private Rigidbody2D rb;

    private bool isDead; // To determine if the enemy is dead or alive.

    private float waitTime; //time left to wait before moving between positions in the patrol array
    public float startWaitTime;

    public Transform[] moveSpots;  // the spots indicated as movement locations for the enemies
    private int randomSpot; // A random spot from the above array

    public bool playerInSight; //is the player inside of the enemies area of influence

    void Start() {

        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   // locate the players sprite in the game
        randomSpot = Random.Range(0, moveSpots.Length); // choose a random spot from within the moveSpots array

    }

    void Update() {

        if (playerInSight == true) {

            rb.position = Vector2.MoveTowards(rb.position, playerPos.position, speed * Time.deltaTime); // if the player is within the enemies AOI move towards the player

        } else { // if the player isn't within the enemies AOI move between the locations in the moveSpots array

            rb.position = Vector2.MoveTowards(rb.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

            if (Vector2.Distance(rb.position, moveSpots[randomSpot].position) < 0.2) {

                if (waitTime <= 0) {    // set the next position when the waitTime is at 0

                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;

                } else {

                    waitTime -= Time.deltaTime;

                }

            }

        }

    }



}
