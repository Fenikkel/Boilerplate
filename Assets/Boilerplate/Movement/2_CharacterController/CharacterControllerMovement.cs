using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    public float m_Speed = 3.0f; //Meters per second
    [Space]
    public bool m_CanPush = false;
    public float m_PushForce = 0.1f;

    Vector3 _MovementDirection = Vector3.zero;

    CharacterController _CharacterController;

    private void Awake()
    {
        _CharacterController = GetComponent<CharacterController>();    
    }

    void Update()
    {
        _MovementDirection.x = Input.GetAxisRaw("Horizontal");
        _MovementDirection.z = Input.GetAxisRaw("Vertical");

        Move(_MovementDirection); //Called within Update because we are not using phisics now
    }

    private void Move(Vector3 direction)
    {
        _CharacterController.SimpleMove(direction.normalized * m_Speed);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
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
