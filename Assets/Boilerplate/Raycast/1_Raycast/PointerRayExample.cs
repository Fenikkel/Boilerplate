using UnityEngine;

public class PointerRayExample : MonoBehaviour
{
    public int m_RayLength = 100;

    Ray _MouseRay;
    RaycastHit _Hit;

    void Update()
    {
        _MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(_MouseRay, out _Hit, m_RayLength))
        {
            // Draw a red line if we hit something
            Debug.DrawLine(_MouseRay.origin, _Hit.point, Color.red);
        }
        else 
        {
            //print("Nothing hitted");
            Debug.DrawLine(_MouseRay.origin, _MouseRay.direction * m_RayLength, Color.green);
        }
    }
}
