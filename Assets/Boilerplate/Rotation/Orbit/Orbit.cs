using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform m_Target; // Orbit center point
    public float m_DegreesPerSecond = 20.0f;

    private void Start()
    {
        // Focus at the point we want to rotate around
        transform.LookAt(m_Target.position);
    }

    void Update() 
    {
        // Makes the camera rotate around Target coords, rotating around its Y axis, n degrees per second
        transform.RotateAround(m_Target.position, Vector3.up, m_DegreesPerSecond * Time.deltaTime);
        
    }
}
