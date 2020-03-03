using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateBehaviour : StateMachineBehaviour
{
    WaveSpawner _monsterSpawner;
    WaveControler _waveControler;
    Stack<Vertex> _path;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _monsterSpawner = animator.GetComponent<WaveSpawner>();
        _waveControler = animator.GetComponent<WaveControler>();
        _monsterSpawner.PathOrganizer.SetNewPath();
        _path = _monsterSpawner.PathOrganizer.GetPath();
        _monsterSpawner.Path = _path;
        foreach (var vertex in _path)
        {
            if(vertex.HeuristicValue!=0)
                vertex.IsOccupied = true;
        }
        if (_waveControler.IsNextWaveExist)
            _waveControler.SpawnNewPack();
        else
            animator.SetTrigger("EndGame");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var vertex in _path)
        {
            vertex.IsOccupied = false;
        }
    }

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
