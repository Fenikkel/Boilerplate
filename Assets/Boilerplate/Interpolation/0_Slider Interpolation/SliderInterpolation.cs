
using UnityEngine;


public class SliderInterpolation : MonoBehaviour
{

    public Transform m_LerpSphere;
    public Transform m_SmoothSphere;

    public void SetInterpolationStep(float newStep) 
    {
        float lerpValue = Mathf.Lerp(-2.75f, 2.75f, newStep);
        m_LerpSphere.position = new Vector3(lerpValue, m_LerpSphere.position.y, m_LerpSphere.position.z);

        float smoothValue = Mathf.SmoothStep(-2.75f, 2.75f, newStep);
        m_SmoothSphere.position = new Vector3(smoothValue, m_SmoothSphere.position.y, m_SmoothSphere.position.z);
    }
}
