using UnityEngine;

public class LineCastExamples : MonoBehaviour
{
    [Header("Basic: Easy Mode")]
    public Transform m_BasicStartPoint;
    public Transform m_BasicEndPoint;

    public GameObject m_BasicObstacle;

    [Header("Layer")]
    public Transform m_LayerStartPoint;
    public Transform m_LayerEndPoint;

    public GameObject m_LayerObstacle;
    public GameObject m_WithoutLayerObstacle;
    public LayerMask m_LineLayerMask;

    [Header("Hit")]
    public Transform m_HitStartPoint;
    public Transform m_HitEndPoint;
    RaycastHit _Hit = new RaycastHit();


    bool _Toggle = false; 
    void Update()
    {
        /* BASIC */
        if (Physics.Linecast(m_BasicStartPoint.position, m_BasicEndPoint.position))
        {
            // There is a collider in the line path (RED)
            Debug.DrawLine(m_BasicStartPoint.position, m_BasicEndPoint.position, Color.red);
        }
        else
        {
            // No colliders in the line path (GREEN)
            Debug.DrawLine(m_BasicStartPoint.position, m_BasicEndPoint.position, Color.green);
        }




        /* LAYERS */
        if (Physics.Linecast(m_LayerStartPoint.position, m_LayerEndPoint.position, m_LineLayerMask))
        {
            // There is a collider with the "Obstacle" layer in the line path (RED)
            Debug.DrawLine(m_LayerStartPoint.position, m_LayerEndPoint.position, Color.red);
        }
        else
        {
            // There may be colliders in the line path, but they don't have assigned the "Obstacle" layer (GREEN)
            Debug.DrawLine(m_LayerStartPoint.position, m_LayerEndPoint.position, Color.green);
        }


        /* HIT POINT */
        if (Physics.Linecast(m_HitStartPoint.position, m_HitEndPoint.position, out _Hit))
        {
            // There is a collider in the line path (RED)
            Debug.DrawLine(m_HitStartPoint.position, m_HitEndPoint.position, Color.red);

            print("Hit at point: " + _Hit.point);
        }
        else
        {
            // No colliders in the path (GREEN)
            Debug.DrawLine(m_HitStartPoint.position, m_HitEndPoint.position, Color.green);
        }


        /* Controls */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_BasicObstacle.SetActive(_Toggle);

            m_LayerObstacle.SetActive(_Toggle);
            m_WithoutLayerObstacle.SetActive(!_Toggle);
            
            _Toggle = !_Toggle; // Swap value
        }
    }
}
