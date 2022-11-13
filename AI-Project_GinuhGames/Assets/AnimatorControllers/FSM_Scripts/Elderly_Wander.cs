using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elderly_Wander : StateMachineBehaviour
{
    Wander_NavMesh_Simple move_wander;
    BlackBoard blackboard;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        move_wander = animator.GetComponent<Wander_NavMesh_Simple>();
        blackboard = animator.GetComponent<BlackBoard>();
        blackboard.energy = 20.0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        blackboard.energy -= Time.deltaTime;

        if (/*Vector3.Distance(blackboard.elder.position, blackboard.bench.transform.position) < blackboard.dist2Bench &&*/ blackboard.energy <= 0.0f) 
            animator.SetTrigger("tired");
        else
            move_wander.Wander();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
