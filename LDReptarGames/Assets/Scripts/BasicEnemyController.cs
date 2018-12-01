using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour {

    public float speed;
    private Transform playerPos;

    private bool playerInSight;

    void Start() {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update() {

        if (playerInSight == true) {

            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        }
    }

    void OnTriggerEnter2D(Collider2D collision) {

        playerInSight = true;

    }

    void OnTriggerExit2D(Collider2D collision) {

        playerInSight = false;

    }

}
