using System.Collections;
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
    public int damage; //set damage in inspector to be 0.5 or 1
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;


    private void Start()
    {
        Invoke("DestroyBulletProjectile", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsSolid);
        if(hitInfo.collider != null) {
            if(hitInfo.collider.CompareTag("EnemyHitbox")) {
                Debug.Log("ENEMY MUST TAKE DAMAGE!");
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }

            if (hitInfo.collider.CompareTag("SlimeBoss")) {

                Debug.Log("BOSS MUST TAKE DAMAGE!");
                hitInfo.collider.GetComponent<TutBossController>().TakeDamage(damage);

            }
            DestroyBulletProjectile();
            
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyBulletProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
