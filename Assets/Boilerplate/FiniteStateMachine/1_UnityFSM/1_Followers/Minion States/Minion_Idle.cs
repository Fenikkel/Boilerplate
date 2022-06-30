using UnityEngine;

public class Minion_Idle : StateMachineBehaviour
{
    [SerializeField]
    private float _FollowArea = 3.0f;

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
        if (Vector3.Distance(_Minion.position, _Player.position) < _FollowArea)
        {
            animator.SetTrigger("Follow");
        }
    }
}
