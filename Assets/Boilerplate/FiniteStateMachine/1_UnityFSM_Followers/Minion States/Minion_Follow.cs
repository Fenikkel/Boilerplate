using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion_Follow : StateMachineBehaviour
{
    [SerializeField]
    private float _FollowSpeed = 1.0f;
    [SerializeField]
    private float _FollowTime = 4.0f;

    [SerializeField]
    private float _MaxDistance = 4.0f;
    [SerializeField]
    private float _MinDistance = 1.0f;

    private Transform _Player;
    private Transform _Minion;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /* Remember to asign the Player tag! */
        _Player = GameObject.FindGameObjectWithTag("Player").transform;

        _Minion = animator.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_FollowTime < 0.0f)
        {
            animator.SetTrigger("Flee");
        }

        _FollowTime -= Time.deltaTime;

        if (_MinDistance < Vector3.Distance(_Minion.position, _Player.position)) // If we are closer than min distance
        {
            _Minion.position = Vector3.MoveTowards(_Minion.position, _Player.position, _FollowSpeed * Time.deltaTime);
        }
            

        if (_MaxDistance < Vector3.Distance(_Minion.position, _Player.position)) // If we are further away than max distance
        {
            animator.SetTrigger("Idle");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _FollowTime = 4.0f;
    }
}
