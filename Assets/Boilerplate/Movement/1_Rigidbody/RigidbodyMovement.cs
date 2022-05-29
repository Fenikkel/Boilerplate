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
        Transform, //For Kinematic rigidbodies
        WrongWay
    }

    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _MovementDirection.x = Input.GetAxisRaw("Horizontal");
        //_MovementDirection.y = We don't want to move the player in the Y axie 
        _MovementDirection.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move(_MovementDirection);
    }

    private void Move(Vector3 direction)
    {
        // We normalize the vector direction to get an uniform velocity in all the directions.
        // When we normalize the vector, we get a vector of magnitude 1.
        // So vectors like (1.0f, 0.0f, 1.0f) don't get more velocity than others.
        // Vector (1.0f, 0.0f, 1.0f) it transforms into (0.7f, 0.0f, 0.7f) when it's normalized.
        // Learn more here: https://en.wikipedia.org/wiki/Unit_vector

        switch (m_Mode)
        {
            case Mode.Force:    // Use the physics to move

                _RigidBody.AddForce(direction.normalized * m_Force, ForceMode.Acceleration); // Ignoring the mass. Without Time.deltaTime!
                break;

            case Mode.Transform:    // Use transform to move, but also have collisions. Use it when isKinematic is enabled!

                _RigidBody.MovePosition(_RigidBody.position + direction.normalized * m_Speed * Time.fixedDeltaTime);
                break;

            case Mode.WrongWay:

                // In most cases you should not modify the velocity directly, as this can result in unrealistic behaviour (use AddForce instead)
                _RigidBody.velocity = direction.normalized * m_Speed;  // Without Time.deltaTime!
                break;

            default:
                Debug.LogWarning("Mode not implemented");
                break;
        }      
    }
}
