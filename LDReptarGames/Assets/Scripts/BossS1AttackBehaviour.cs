using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossS1AttackBehaviour : StateMachineBehaviour {

    private float timer;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    public float speed;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
        speed = GameObject.Find("SlimeBoss").GetComponent<TutBossController>().speed;
	
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (timer <= 0 ) {

            animator.SetTrigger("idle");

        } else {

            timer -= Time.deltaTime;

        }

        Vector2 target = new Vector2(playerPos.position.x, playerPos.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
	
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {


	
	}

}
