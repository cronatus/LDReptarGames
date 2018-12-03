using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossS1IdleBehaviour : StateMachineBehaviour {

    public float timer;
    public float minTime;
    public float maxTime;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        timer = Random.Range(minTime, maxTime);

	}

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
        if (timer <= 0) {

            animator.SetTrigger("attack");

        } else {

            timer -= Time.deltaTime;

        }

	}

	// OnStateExit is called before OnStateExit is called on any state inside this state machine
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	


	}


}
