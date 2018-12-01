﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWeapon : MonoBehaviour {

    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

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
                timeBetweenShots = startTimeBetweenShots;
            }
        }
        else {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}