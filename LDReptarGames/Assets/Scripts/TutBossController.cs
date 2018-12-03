using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutBossController : MonoBehaviour {

    public int maxBossHealth; // the Boss' max health
    private int bossHealth; // The Boss' health
    public int damage; // The Damage the Boss does
    private float timeBtwDamage = 1.5f;

    public Slider healthBar;
    private Animator anim;
    public bool isDead;
    

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        bossHealth = maxBossHealth;

	}
	
	// Update is called once per frame
	void Update () {

        if (bossHealth <= maxBossHealth/2) {

            anim.SetTrigger("stageTwo");

        } else if (bossHealth <= 0) {

            anim.SetTrigger("death");

        }
		
        if(timeBtwDamage > 0) {

            timeBtwDamage -= Time.deltaTime;

        }

        healthBar.value = bossHealth;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player") && isDead == false) {

            if(timeBtwDamage <= 0) {

                other.GetComponent<PlayerController>().playerHealth -= damage; // if the player collides with the boss, reduce their health.

            }

        }

    }


}
