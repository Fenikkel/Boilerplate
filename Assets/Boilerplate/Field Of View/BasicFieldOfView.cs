using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial: https://youtu.be/TfhPBAe9Tt8?t=612

public class BasicFieldOfView : MonoBehaviour
{
    public Light m_SpotLight;
    public float m_ViewDistance;

    float _ViewAngle;

    Transform _Player;

    public LayerMask m_ViewMask;


    void Start()
    {
        // Get the player reference (remember: TAG the player!)
        _Player = GameObject.FindGameObjectWithTag("Player").transform;

        // Use the Spotlight as vision cone
        _ViewAngle = m_SpotLight.spotAngle;
    }


    void Update()
    {
        if (CanSeePlayer())
        {
            m_SpotLight.color = Color.red;
        }
        else
        {
            m_SpotLight.color = Color.yellow;
        }
    }

    bool CanSeePlayer() 
    {
        // Check the distance with the player
        if (Vector3.Distance(transform.position, _Player.position) < m_ViewDistance)
        {
            // Get the vector direction to the player and normalize it
            Vector3 directionToPlayer = _Player.position - transform.position;
            directionToPlayer = directionToPlayer.normalized;

            /* 
             * Get the angle between the vector that points the player from our field of view center 
             * and the vector that points from our field of view center to the local foward 
             */
            float angleBetween = Vector3.Angle(transform.forward, directionToPlayer);

            // Check if the player is within the FoV angle
            if (angleBetween < _ViewAngle / 2f)
            {
                //Check if there are obtacles between the vision and the player
                if (!Physics.Linecast(transform.position, _Player.position, m_ViewMask)) // If we don't hit anything
                {
                    return true; // We see the player
                }
            }
        }

        return false; // We can't see the player
    }


    private void OnDrawGizmos()
    {
        //Draw red line for visualize the View Distance
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * m_ViewDistance);
    }
}
