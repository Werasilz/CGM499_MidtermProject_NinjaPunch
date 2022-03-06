using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPunchStateMachine : StateMachineBehaviour
{
    private int randomAttack;
    private bool startRandomAttack;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Attack(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        startRandomAttack = false;
    }

    private void Attack(Animator animator)
    {
        if (startRandomAttack == false)
        {
            startRandomAttack = true;
            randomAttack = Random.Range(0, 3);
        }

        switch (randomAttack)
        {
            case 0:
                animator.CrossFade("Punch1", 0.2f);
                break;
            case 1:
                animator.CrossFade("Punch2", 0.2f);
                break;
            case 2:
                animator.CrossFade("Punch3", 0.2f);
                break;
            case 3:
                animator.CrossFade("Punch4", 0.2f);
                break;
        }
    }
}
