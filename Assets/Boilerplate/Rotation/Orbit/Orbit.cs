using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform m_Target; // Orbit center point
    public float m_DegreesPerSecond = 20.0f;

    void Update() 
    {
        // Makes the camera rotate around Target coords, rotating around its Y axis, n degrees per second
        transform.RotateAround(m_Target.position, Vector3.up, m_DegreesPerSecond * Time.deltaTime);
        transform.LookAt(m_Target.position);
    }
}
