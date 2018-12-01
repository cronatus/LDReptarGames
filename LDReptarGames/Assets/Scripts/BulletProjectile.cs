﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    //In the Inspector, this script will be attached to the projectile Arrow.
    //Once attached, set Speed (roughly 8-12, dependant when testing) and the Life Time of however long you want it to last on the screen (2-4 seconds).
    //With the projectile arrows it might be a nice effect to have arrow linger around for longer than instantly disappearing.

    //Make sure to add Destroy Effect is wanted.

    public float speed;
    public float lifeTime;

    public float distance; //set distance in inspector to roughly 0.5
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null) {
            if(hitInfo.collider.CompareTag("Enemy")) {
                Debug.Log("ENEMY MUST TAKE DAMAGE!");
            }
            DestroyBulletProjectile();
        }


        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroyBulletProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
