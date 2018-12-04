using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutBossController : MonoBehaviour {

    public int maxBossHealth; // the Boss' max health
    private int bossHealth; // The Boss' health
    public int damage; // The Damage the Boss does
    private float timeBtwDamage = 1.5f;

    public Slider healthBar;
    private Animator anim;
    public float speed;
    public bool isDead;
    private Rigidbody2D rb;
    

	// Use this for initialization
	void Start () {

        speed = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bossHealth = maxBossHealth;

	}
	
	// Update is called once per frame
	void Update () {

        if (bossHealth <= maxBossHealth/2) {

            anim.SetTrigger("stageTwo");

        }
        if (bossHealth <= 0) {

            //anim.SetTrigger("death");
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");

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

    public void TakeDamage(int damage) {
        bossHealth -= damage;
    }

    public void spawn() {

        speed = 1;
        //GetComponent<BossS1AttackBehaviour>().speed = 1;
        rb.constraints = RigidbodyConstraints2D.None;
        healthBar.gameObject.SetActive(true);

    }


}
