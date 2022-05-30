using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_CharacterController : MonoBehaviour
{
    const float JUMP_OFFSET = -2.0f; // -2.0f means that the jump will do exactly the _JumpHeight.  

    [SerializeField]
    private float _JumpHeight = 1.0f; 
    [SerializeField]
    private float _Gravity = -9.81f;

    private CharacterController _CharacterController;
    private Vector3 _PlayerVelocity_Y;

    private void Start()
    {
        _CharacterController = gameObject.GetComponent<CharacterController>();

        _CharacterController.minMoveDistance = 0.0f; // The default value (0.001) don't let  the .isGrounded work properly
    }

    void Update()
    {
        if (_CharacterController.isGrounded && _PlayerVelocity_Y.y < 0.0f) // If we are in the ground and we don't have any upwards velocity...
        {
            // Anulate the cumulative gravity velocity 
            _PlayerVelocity_Y.y = 0f;
        }

        /* JUMP */
        if (Input.GetButtonDown("Jump") && _CharacterController.isGrounded)
        {
            _PlayerVelocity_Y.y += Mathf.Sqrt(_JumpHeight * JUMP_OFFSET * _Gravity); // Add a jump impulse in the velocity vector
        }

        _PlayerVelocity_Y.y += _Gravity * Time.deltaTime; // Add the gravity weight to the the velocity 
        _CharacterController.Move(_PlayerVelocity_Y * Time.deltaTime); // Move vertically
    }
}
