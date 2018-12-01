using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutBossController : MonoBehaviour {

    public int bossHealth; // The Boss' health
    public int damage; // The Damage the Boss does
    private float timeBtwDamage = 1.0f;


    public bool isDead;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(timeBtwDamage > 0) {

            timeBtwDamage -= Time.deltaTime;

        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player") && isDead == false) {

            if(timeBtwDamage <= 0) {

                other.GetComponent<PlayerController>().playerHealth -= damage; // if the player collides with the boss, reduce their health.

            }

        }

    }


}
