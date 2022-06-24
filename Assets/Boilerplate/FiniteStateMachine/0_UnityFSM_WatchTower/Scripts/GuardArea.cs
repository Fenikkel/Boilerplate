using UnityEngine;

public class GuardArea : MonoBehaviour
{
    private Animator _GuardAnimator;

    private void Start()
    {
        _GuardAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _GuardAnimator.SetBool("EnemyDetected", true);
        print("OnTriggerEnter: Enemy detected");
    }
    private void OnTriggerExit(Collider other)
    {
        _GuardAnimator.SetBool("EnemyDetected", false);
        print("OnTriggerExit: Enemy lost");
    }
}
