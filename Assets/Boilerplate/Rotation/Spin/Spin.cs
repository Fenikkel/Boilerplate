using UnityEngine;

public class Spin : MonoBehaviour
{
    public float m_DegreesPerSecond = 10.0f;
    [Space]
    public bool m_SpinX = true; // Horizontal axie
    public bool m_SpinY = false; // Vertical axie
    public bool m_SpinZ = false; // Depth axie

    void Update()
    {
        if (m_SpinX)
        {
            transform.Rotate(Vector3.up, m_DegreesPerSecond * Time.deltaTime);
        }

        if (m_SpinY)
        {
            transform.Rotate(Vector3.right, m_DegreesPerSecond * Time.deltaTime);
        }

        if (m_SpinZ)
        {
            transform.Rotate(Vector3.forward, m_DegreesPerSecond * Time.deltaTime);
        }
    }
}
