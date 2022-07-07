using UnityEngine;

public class CameraRayExample : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            // Draw a red line if we hit something
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        else 
        {
            //print("Nothing hitted");
        }
    }
}
