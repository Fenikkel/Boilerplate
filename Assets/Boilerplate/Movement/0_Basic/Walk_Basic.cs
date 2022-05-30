using UnityEngine;

public class Walk_Basic : MonoBehaviour
{
    public float m_Speed = 1.0f; //Meters per second

    Vector3 _MovementDirection = Vector3.zero;

    void Update()
    {
        //_MovementDirection.x = Input.GetAxisRaw("Horizontal");
        //_MovementDirection.z = Input.GetAxisRaw("Vertical");
        _MovementDirection.x = Input.GetAxis("Horizontal");
        _MovementDirection.z = Input.GetAxis("Vertical");

        Move(_MovementDirection);
    }

    private void Move(Vector3 direction)
    {
        transform.position += direction.normalized * m_Speed * Time.deltaTime; //normalize vector to have constant velocity when we push two keys at the same time
        //transform.position += direction * m_Speed * Time.deltaTime;
    }
}
