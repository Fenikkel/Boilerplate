using UnityEngine;

public class AnimationControls : MonoBehaviour
{
    //https://docs.unity3d.com/Manual/class-Transition.html

    public Animator m_InstaAC; //Instantaneous transition (no transition)
    public Animator m_TransitionAC; //It has a 0.2 seconds of transition
    public Animator m_ExitTimeAC; // Transition between animations when they finished

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_InstaAC.SetTrigger("Go");
            m_TransitionAC.SetTrigger("Go");
            m_ExitTimeAC.SetTrigger("StartAnim");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_InstaAC.SetTrigger("Return");
            m_TransitionAC.SetTrigger("Return");
        }
    }
}
