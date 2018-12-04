using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnboss : MonoBehaviour {

    public GameObject GO;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {

            //GameObject.FindGameObjectWithTag("SlimeBoss").GetComponent<TutBossController>().spawn();
            GO.GetComponent<TutBossController>().spawn();
        
            
        }

    }
}
