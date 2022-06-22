using UnityEngine;

public class TimeInterpolation : MonoBehaviour
{

    public Transform m_LerpSphere;
    public Transform m_SmoothSphere;

    public float m_InterpolationTime = 1.0f;

    bool _Left = true;
    float _Timmer = 0.0f;
    float _InitialLerpPosition; // The position of the sphere before start doing the interpolation
    float _InitialSmoothPosition;

    void Update()
    {
        /* Increase the time passed */
        _Timmer += Time.deltaTime;

        /* Check the input */
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _Left = true;

            /* Reset timmer */
            _Timmer = 0.0f;

            /* Save the current spheres positions */
            _InitialLerpPosition = m_LerpSphere.position.x;
            _InitialSmoothPosition = m_SmoothSphere.position.x;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _Left = false;

            /* Reset timmer */
            _Timmer = 0.0f;

            /* Save the current spheres positions */
            _InitialLerpPosition = m_LerpSphere.position.x;
            _InitialSmoothPosition = m_SmoothSphere.position.x;
        }
        
        /* Convert the time passed into a value between 0f and 1f */
        float step = _Timmer / m_InterpolationTime;

        /* LERP */
        /* Get the new position value */
        float lerpPosX;

        if (_Left)
        {
            lerpPosX = Mathf.Lerp(_InitialLerpPosition, -2.75f, step);     
        }
        else
        {
            lerpPosX = Mathf.Lerp(_InitialLerpPosition, 2.75f, step);
        }

        /* Asign the new position */
        m_LerpSphere.position = new Vector3(lerpPosX, m_LerpSphere.position.y, m_LerpSphere.position.z);


        /* SMOOTH STEP */
        /* Get the new position value */
        float smoothPosX;

        if (_Left)
        {
            smoothPosX = Mathf.SmoothStep(_InitialSmoothPosition, -2.75f, step);
        }
        else
        {
            smoothPosX = Mathf.SmoothStep(_InitialSmoothPosition, 2.75f, step);
        }

        /* Asign the new position */
        m_SmoothSphere.position = new Vector3(smoothPosX, m_SmoothSphere.position.y, m_SmoothSphere.position.z);
    }
}
