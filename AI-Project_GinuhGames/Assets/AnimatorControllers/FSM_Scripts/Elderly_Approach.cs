using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elderly_Approach : StateMachineBehaviour
{
    Seek_NavMesh move_seek;
    BlackBoard blackboard;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        move_seek = animator.GetComponent<Seek_NavMesh>();
        blackboard = animator.GetComponent<BlackBoard>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(blackboard.elder.position, blackboard.allBenches[0].transform.position) < 2.0f)
        {
            animator.SetTrigger("sit");  // approach trigger ON
        }
        else
            move_seek.Seek(blackboard.allBenches[0]);
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
