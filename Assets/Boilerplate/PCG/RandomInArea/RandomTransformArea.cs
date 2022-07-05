using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransformArea : MonoBehaviour
{
    /*
        transform.localScale as boundaries of our cubic area
        transform.position as center of our cubic area
     */

    public int m_NumberOfInstance = 4;
    public int m_Seed = 10;

    void Start()
    {
        // Set a custom seed
        Random.InitState(m_Seed); // If we don't initialize it, it gets this value: Random.InitState((int)DateTime.Now.Ticks)

        // Instance inside the area
        for (int i = 0; i < m_NumberOfInstance; i++)
        {
            CreatePrimitiveInside();
        }   
    }


    private void CreatePrimitiveInside() 
    {

        // Get a random position inside the area as if the area were in the center of the world (0, 0, 0)
        float xBoundary = transform.localScale.x / 2.0f;

        float xPos = UnityEngine.Random.Range(-xBoundary, xBoundary);

        float yBoundary = transform.localScale.y / 2.0f;

        float yPos = UnityEngine.Random.Range(-yBoundary, yBoundary);

        float zBoundary = transform.localScale.z / 2.0f;
        float zPos = UnityEngine.Random.Range(-zBoundary, zBoundary);
 
        Vector3 newPosition = new Vector3(xPos, yPos, zPos);

        // Move the point inside the area position
        newPosition = newPosition + transform.position;

        
        // Create a primitive at the center of the world (0, 0, 0)
        GameObject newPrimitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // Move the primitive into the random position
        newPrimitive.transform.position = newPosition;
    }
}
