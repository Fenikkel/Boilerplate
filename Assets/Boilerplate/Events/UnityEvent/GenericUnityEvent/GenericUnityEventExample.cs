using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyMultipleFloatEvent : UnityEvent<float, float, float>
{
}

public class GenericUnityEventExample : MonoBehaviour
{
    public MyMultipleFloatEvent m_MyCustomUnityEvent;

    void Start()
    {
        m_MyCustomUnityEvent.AddListener(Ping);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            m_MyCustomUnityEvent.Invoke(0.2f, 1.3f, 4.4f);
        }
    }

    void Ping(float i, float j, float u)
    {
        Debug.Log("One: " + i);
        Debug.Log("Two: " + j);
        Debug.Log("Three: " + u);
    }
}
