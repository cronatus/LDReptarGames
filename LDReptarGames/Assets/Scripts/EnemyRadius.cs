using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadius : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {

        GetComponentInParent<BasicEnemyController>().playerInSight = true;

    }

    void OnTriggerExit2D(Collider2D collision) {

        GetComponentInParent<BasicEnemyController>().playerInSight = false;

    }
}
