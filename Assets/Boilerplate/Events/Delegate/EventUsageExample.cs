using UnityEngine;

public class EventUsageExample : MonoBehaviour
{
    public GameObject m_Target;

    private void OnEnable()
    {
        /*
        * "event" label on myDelegate variable adds a layer of abstraction and protection on delegate.
        * This protection prevents client of the delegate from resetting the delegate and invocation list.
        * We are forced to use the "+=" and "-="
        * We can't use "="
        */
        // EventHandler.myEvent = ChangePosition; -> Error

        EventHandler.myEvent += ChangePosition;
        EventHandler.myEvent += ChangeColor;
        EventHandler.myEvent += PrintSomething;
    }

    // Unsubscribing Delegate
    void OnDisable()
    {
        EventHandler.myEvent -= ChangeColor;
        EventHandler.myEvent -= ChangePosition;
        EventHandler.myEvent -= PrintSomething;

        // EventHandler.myEvent = null; -> Error
    }

    public void ChangePosition(float value)
    {
        m_Target.transform.position = new Vector2(m_Target.transform.position.x + value, m_Target.transform.position.y);
    }

    void ChangeColor(float value)
    {
        Renderer renderer = m_Target.GetComponent<Renderer>();

        renderer.material.color = new Color(value, value, value);
    }

    void PrintSomething(float value)
    {
        print("Event called. Value: " + value);
    }
}