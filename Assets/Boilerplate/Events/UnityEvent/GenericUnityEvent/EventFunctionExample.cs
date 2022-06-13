using UnityEngine;

public class EventFunctionExample : MonoBehaviour
{
    Transform _Transform;

    void Awake()
    {
        _Transform = GetComponent<Transform>();
    }

    public void RotateMyself(float rotX, float rotY, float rotZ) 
    {
        _Transform.Rotate(rotX, rotY, rotZ);
    }
}
