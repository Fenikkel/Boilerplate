using UnityEngine;

public class WatchTower_Alert : StateMachineBehaviour
{
    private AudioSource _TowerAudio;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _TowerAudio = animator.gameObject.GetComponent<AudioSource>();
        _TowerAudio.Play();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _TowerAudio.Stop();
    }
}
