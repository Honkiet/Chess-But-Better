using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : PieceBaseFSM
{
	public Ranged ranged;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		base.OnStateEnter(animator, stateInfo, layerIndex);
		ranged = animator.gameObject.GetComponent<Ranged>();
		ranged.StartFiring();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		// Every 2 seconds calculate the distace to all enemys and Look at opponent
		GameObject opponent = ;
		ranged.transform.LookAt(opponent.transform.position);
		// check if a mate is between and swap targets

		// Change the Lookat to movement prediction
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		ranged.StopFiring();
	}
}
