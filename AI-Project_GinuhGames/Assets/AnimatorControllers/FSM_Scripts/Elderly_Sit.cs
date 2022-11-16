using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elderly_Sit : StateMachineBehaviour
{
    BlackBoard blackboard;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        blackboard = animator.GetComponent<BlackBoard>();
        blackboard.energy = 0.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        blackboard.energy += 2*Time.deltaTime;

        if (blackboard.energy <= 20.0f)
        {
            Debug.Log(blackboard.elder.forward);
            blackboard.elder.Rotate(new Vector3(1.0f, 0.0f, 0.0f), 245.0f);
            Debug.Log(blackboard.elder.forward);


        }
        else
        {
            animator.ResetTrigger("tired"); // tired trigger OFF
            animator.ResetTrigger("sit"); // sitted trigger OFF
            animator.SetTrigger("rested"); // rested trigger ON


        }
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
