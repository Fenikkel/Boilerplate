using UnityEngine;

public class RayCastExamples : MonoBehaviour
{
    public Transform m_StartPoint;

    [Header("Config")]
    public LayerMask m_RayLayerMask;
    [Range(2.5f, 8.0f)]
    public float m_RayLength = 5.0f;
    [Range(-90.0f, 90.0f)]
    public float m_RotSpeed = 25.0f; // Degrees per second

    RaycastHit _Hit = new RaycastHit();

    Vector3 _DrawEndPoint = Vector3.zero;


    void Update()
    {
        /* BASIC */
        _DrawEndPoint.x = m_StartPoint.right.x * 100; // Infinite
        _DrawEndPoint.y = m_StartPoint.position.y;
        _DrawEndPoint.z = m_StartPoint.right.z * 100; // Infinite

        if (Physics.Raycast(m_StartPoint.position, m_StartPoint.right)) // Infinite ray
        {
            // There is a collider in the line path (RED)
            Debug.DrawLine(m_StartPoint.position, _DrawEndPoint, Color.red);
        }
        else
        {
            // No colliders in the line path (GREEN)
            Debug.DrawLine(m_StartPoint.position, _DrawEndPoint, Color.green);
        }


        /* LAYERS */
        _DrawEndPoint.x = m_StartPoint.forward.x * 100; // Infinite
        _DrawEndPoint.y = m_StartPoint.position.y;
        _DrawEndPoint.z = m_StartPoint.forward.z * 100; // Infinite

        if (Physics.Raycast(m_StartPoint.position, m_StartPoint.forward, m_RayLayerMask)) // Infinite ray
        {
            // There is a collider with the "Obstacle" layer in the line path (RED)
            Debug.DrawLine(m_StartPoint.position, _DrawEndPoint, Color.red);
        }
        else
        {
            // There may be colliders in the ray path, but they don't have assigned the "Obstacle" layer (YELLOW)
            Debug.DrawLine(m_StartPoint.position, _DrawEndPoint, Color.yellow);
        }


        /* HIT POINT */
        _DrawEndPoint.x = -m_StartPoint.forward.x * m_RayLength; // Infinite
        _DrawEndPoint.y = m_StartPoint.position.y;
        _DrawEndPoint.z = -m_StartPoint.forward.z * m_RayLength; // Infinite

        if (Physics.Raycast(m_StartPoint.position, -m_StartPoint.forward, out _Hit, m_RayLength))
        {
            // There is a collider with the "Obstacle" layer in the line path (RED)

            Debug.DrawLine(m_StartPoint.position, _Hit.point, Color.red);
        }
        else
        {
            // There may be colliders in the ray path, but they don't have assigned the "Obstacle" layer (BLUE)
            Debug.DrawLine(m_StartPoint.position, _DrawEndPoint, Color.blue);
        }


        /* Rotate the point */
        m_StartPoint.Rotate(Vector3.up * Time.deltaTime * m_RotSpeed, Space.World);
    }
}
