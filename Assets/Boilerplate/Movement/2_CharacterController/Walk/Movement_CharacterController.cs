using UnityEngine;

public class Movement_CharacterController : MonoBehaviour
{
    public Mode m_Mode = Mode.Velocity;
    [Space]
    public float m_Speed = 3.0f; //Meters per second
    [Space]
    public bool m_CanPush = false;
    public float m_PushForce = 0.1f;

    Vector3 _MovementDirection = Vector3.zero;

    CharacterController _CharacterController;

    public enum Mode
    {
        Velocity, // Simple (you can't move in the Y axie)
        Transform // Complex (you implement the Y movement, also the gravity)
    }

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();    
    }

    void Update()
    {
        _MovementDirection.x = Input.GetAxisRaw("Horizontal");
        //_MovementDirection.y = We don't want to move the player in the Y axie 
        _MovementDirection.z = Input.GetAxisRaw("Vertical");

        Move(_MovementDirection); //Called within Update because we are not using phisics now
    }

    private void Move(Vector3 direction)
    {
        switch (m_Mode)
        {
            case Mode.Velocity:
                // Without Time.deltaTime because we are modifying a velocity vector! (_CharacterController.velocity)
                // "Y" velocity is ignored
                _CharacterController.SimpleMove(direction.normalized * m_Speed); 
                break;

            case Mode.Transform:
                //Does not use gravity and you implement the Y movement
                //We add the values directly to the Transform, so we use Time.deltaTime
                _CharacterController.Move(direction.normalized * Time.deltaTime * m_Speed); 
                break;

            default:
                break;
        }

        // Face forward into the walking direction
        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) // On collision, move the other GameObject if it has a rigidbody
    {
        if (m_CanPush)
        {
            Rigidbody rigidbody = hit.collider.attachedRigidbody; // Get the other rigidbody

            if (rigidbody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * m_PushForce, transform.position, ForceMode.Impulse);
            }
        }
    }
}
