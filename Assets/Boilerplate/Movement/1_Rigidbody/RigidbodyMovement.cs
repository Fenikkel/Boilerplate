using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Mode m_Mode = Mode.Force;
    
    public float m_Force = 12.0f;
    public float m_Speed = 3.0f; //Meters per second

    Vector3 _MovementDirection = Vector3.zero;
    Rigidbody _RigidBody;

    public enum Mode 
    {
        Force,
        Transform,
        WrongWay
    
    }

    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _MovementDirection.x = Input.GetAxisRaw("Horizontal");
        _MovementDirection.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move(_MovementDirection);
    }

    private void Move(Vector3 direction)
    {
        switch (m_Mode)
        {
            case Mode.Force:    // Use the physics to move

                _RigidBody.AddForce(direction.normalized * m_Force, ForceMode.Acceleration); // Ignoring the mass
                break;

            case Mode.Transform:    // Use transform to move (but having collisions)

                _RigidBody.MovePosition(_RigidBody.position + direction.normalized * m_Speed * Time.fixedDeltaTime);
                break;

            case Mode.WrongWay:

                // In most cases you should not modify the velocity directly, as this can result in unrealistic behaviour (use AddForce instead)
                _RigidBody.velocity = direction.normalized * m_Speed; 
                break;

            default:
                Debug.LogWarning("Mode not implemented");
                break;
        }      
    }
}
