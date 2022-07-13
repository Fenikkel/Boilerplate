using UnityEngine;

public class MushroomCreator : MonoBehaviour
{
    public int m_RayLength = 100;

    public float m_PrimitiveSize = 0.5f;

    Ray _MouseRay;
    RaycastHit _Hit;
    Vector3 _Size;
    GameObject _InstancedFolder;

    GameObject temp;

    private void Start()
    {
        _Size = new Vector3(m_PrimitiveSize, m_PrimitiveSize, m_PrimitiveSize);
        _InstancedFolder = new GameObject();
        _InstancedFolder.name = "Spheres folder";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Instance a sphere
        {
            _MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(_MouseRay, out _Hit, m_RayLength))
            {
                // Draw a red line if we hit something
                Debug.DrawLine(_MouseRay.origin, _Hit.point, Color.red);

                // Spawn primitive
                temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                temp.transform.position = _Hit.point;
                temp.transform.localScale = _Size;

                temp.transform.parent = _InstancedFolder.transform;
            }
            else
            {
                //print("Nothing hitted");
                Debug.DrawLine(_MouseRay.origin, _MouseRay.direction * m_RayLength, Color.green);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // Delete spheres
        {
            foreach (Transform sphere in _InstancedFolder.transform)
            {
                Destroy(sphere.gameObject);
            }
        }
    }
}
