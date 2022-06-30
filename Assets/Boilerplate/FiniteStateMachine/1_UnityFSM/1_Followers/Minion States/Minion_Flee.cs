using UnityEngine;

public class Minion_Flee : StateMachineBehaviour
{
    [SerializeField]
    private float _FleeSpeed = 1.0f;

    [SerializeField]
    private float _MaxDistance = 5.0f;

    private Transform _Player;
    private Transform _Minion;

    private Vector3 _FleeDirection;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /* Remember to asign the Player tag! */
        _Player = GameObject.FindGameObjectWithTag("Player").transform;

        _Minion = animator.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /* Get the vector direction */
        _FleeDirection = _Minion.position - _Player.position;

        /* Normalize the vector direction 
         * This make the values between 0 and 1
         * This prevents extra acceleration due a big values
         */
        _FleeDirection = _FleeDirection.normalized;

        /* Move a bit in the flee direction acording the world space */
        _Minion.Translate(_FleeDirection * Time.deltaTime * _FleeSpeed, Space.World);

        if (_MaxDistance < Vector3.Distance(_Player.position, _Minion.position))
        {
            animator.SetTrigger("Idle");
        }
    }
}
