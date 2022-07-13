using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbaMovement : MonoBehaviour
{
    public float m_Speed = 1.0f;

    public float m_RayLength = 3.0f;

    Transform _Rumba;

    private void Start()
    {
        _Rumba = GetComponent<Transform>();
    }

    void Update()
    {
        /* Draw Ray */
        Debug.DrawLine(_Rumba.position, _Rumba.position + _Rumba.forward * m_RayLength, Color.red);

        /* Check collisions */ 
        if (Physics.Raycast(_Rumba.position, _Rumba.forward, m_RayLength))
        {
            print("DETECTADO");
            _Rumba.Rotate(new Vector3(0f, 90f,0f), Space.Self);
        }

        /* Always move */
        Move(_Rumba.forward);
    }

    private void Move(Vector3 direction)
    {
        /* Mode 1 */
        _Rumba.Translate(direction.normalized * m_Speed * Time.deltaTime, Space.World); // "direction" is world space

        /* Mode 2 */
        //transform.position += direction.normalized * m_Speed * Time.deltaTime; //normalize vector to have constant velocity 
        
    }
}
