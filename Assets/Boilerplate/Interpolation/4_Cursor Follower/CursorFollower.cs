using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorFollower : MonoBehaviour
{
    /*
    X -> 0 to 1920 (left to right)
    Y -> 1080 to 0 (up to down)
    */

    [Range(0.0f, 1.0f)]
    public float m_FollowingForce = 0.94f;

    RectTransform _FollowerRT;

    Vector2 _LastPos = Vector2.zero;


    void Start()
    {
        _FollowerRT = GetComponent<RectTransform>();
    }


    void Update()
    {
        _LastPos = Vector2.Lerp(Input.mousePosition, _LastPos, m_FollowingForce * Time.deltaTime);

        _FollowerRT.position = _LastPos; // With .position it doesn't matter were you anchored the image
    }
}
