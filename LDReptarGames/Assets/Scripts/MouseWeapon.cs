using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Help provided with code from following link with MouseWeapon and BulletProjectile: https://www.youtube.com/watch?v=bY4Hr2x05p8

public class MouseWeapon : MonoBehaviour {

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    public GameObject fireArrowSound;

    private float timeBetweenShots;
    public float startTimeBetweenShots; //set this in the inspector to roughly between .5 to 1 second

	private void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationOnZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationOnZ + offset);

        if(timeBetweenShots <= 0) {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                Instantiate(fireArrowSound, transform.position, Quaternion.identity);
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
