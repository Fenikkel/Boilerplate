using UnityEngine;

public class Movement_CharacterController : MonoBehaviour
{
    const float JUMP_OFFSET = -2.0f; // -2.0f means that the jump will do exactly the _JumpHeight.  

    [Header("Movement")]
    [SerializeField]
    private float _Speed = 3.0f; //Meters per second

    [Header("Jump")]
    [SerializeField]
    private float _JumpHeight = 1.0f;
    [SerializeField]
    private float _Gravity = -9.81f;

    [Header("Push")]
    [SerializeField]
    private bool _CanPush = true;
    [SerializeField]
    private float _PushForce = 0.1f;
    [SerializeField]
    private ForceMode _PushMode = ForceMode.Impulse;

    [Header("Rotation")]
    [SerializeField]
    private bool _FaceDirection = true;


    CharacterController _CharacterController;
    Vector3 _PlayerVelocity_XZ = Vector3.zero;
    Vector3 _PlayerVelocity_Y = Vector3.zero;
    bool _Grounded = false;

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();    
    }
    private void Start()
    {
        _CharacterController.minMoveDistance = 0.0f; // The default value (0.001) don't let  the .isGrounded work properly
    }

    void Update()
    {
        CheckGrounded(); // Always check this first
        UpdateDirection();
        MovementXZ(_PlayerVelocity_XZ); //Called within Update because we are not using phisics now
        MovementY();
    }

    private void UpdateDirection() 
    {      
        _PlayerVelocity_XZ.x = Input.GetAxis("Horizontal"); //Use GetAxisRaw for instant start and stop
        _PlayerVelocity_XZ.z = Input.GetAxis("Vertical");
    }

    private void CheckGrounded() 
    {
        // Get the value at the start of the Update to be sure that the value will be the same in all the iteration.
        _Grounded = _CharacterController.isGrounded;

        // If we are in the ground and we don't have any upwards velocity...
        if (_Grounded && _PlayerVelocity_Y.y < 0.0f)
        {
            // Anulate the cumulative gravity velocity 
            _PlayerVelocity_Y.y = 0f;
        }
    }

    private void MovementXZ(Vector3 direction)
    {
        /* WALK */
        _CharacterController.Move(direction.normalized * Time.deltaTime * _Speed);

        // Face forward into the walking direction
        if (_FaceDirection && direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }
    }

    private void MovementY() 
    {
        /* JUMP */
        if (Input.GetButtonDown("Jump") && _Grounded)
        {
            _PlayerVelocity_Y.y += Mathf.Sqrt(_JumpHeight * JUMP_OFFSET * _Gravity); // Add a jump impulse in the velocity vector
        }

        /* GRAVITY */
        _PlayerVelocity_Y.y += _Gravity * Time.deltaTime; // Add the gravity weight to the the velocity 

        _CharacterController.Move(_PlayerVelocity_Y * Time.deltaTime); // Move vertically
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) // On collision, move the other GameObject if it has a rigidbody
    {
        if (_CanPush)
        {
            Rigidbody rigidbody = hit.collider.attachedRigidbody; // Get the other rigidbody

            if (rigidbody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * _PushForce, transform.position, _PushMode);
            }
        }
    }
}
