using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    /*
     * For the health system in the code just for reference since integers are being used;
     *  1 Health = Half a Heart
     *  2 Health = A Full Heart
     *  3 Health = A Full Heart & Half a Heart
     *  4 Health = 2 Full Hearts and so on...
     */

    public int health;
    public int damage;
    public GameObject deathEffect;

    private void Update() {
        if (health <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Debug.Log("YOU HAVE BEEN DESTROYED");
            Destroy(transform.parent.gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
    }


    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerController>().playerHealth -= damage;

        }

    }


}
