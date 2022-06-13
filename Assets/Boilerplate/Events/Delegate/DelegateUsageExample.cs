using UnityEngine;

public class DelegateUsageExample : MonoBehaviour
{
    public GameObject m_Target;

    void OnEnable()
    {
        DelegateHandler.myDelegate = ChangePosition;
        DelegateHandler.myDelegate += ChangeColor;
        DelegateHandler.myDelegate += PrintSomething;
    }

    // Unsubscribing Delegate
    void OnDisable()
    {
        // Individual way
        DelegateHandler.myDelegate -= ChangeColor;

        // All way
        DelegateHandler.myDelegate = null;
    }

    void ChangePosition()
    {
        m_Target.transform.position = new Vector2(m_Target.transform.position.x - 1.0f, m_Target.transform.position.y);
    }

    void ChangeColor()
    {
        Renderer renderer = m_Target.GetComponent<Renderer>();

        renderer.material.color = Color.yellow;
    }

    void PrintSomething()
    {
        print("Delegate called");
    }
}