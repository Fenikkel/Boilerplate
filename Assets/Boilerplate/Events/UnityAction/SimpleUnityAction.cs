using UnityEngine;
using UnityEngine.Events;

public class SimpleUnityAction : MonoBehaviour
{
    public UnityAction m_UnityActionOne; // Can't have arguments
    public UnityAction m_UnityActionTwo;

    private float _CallInterval = 1.0f;  
    private float _Timmer = 0.0f;

    private bool _Swapper = true;

    private void OnEnable()
    {
        m_UnityActionOne = PrintOne;
        m_UnityActionOne += PrintSomething;

        m_UnityActionTwo = PrintTwo;
        m_UnityActionTwo += PrintSomething;
    }

    private void OnDisable()
    {
        // Individual way
        m_UnityActionOne -= PrintOne;
        m_UnityActionOne -= PrintSomething;

        // All way
        m_UnityActionTwo = null;
    }

    private void Update()
    {
        if (0.0f < _Timmer)
        {
            _Timmer -= Time.deltaTime; 
        }
        else 
        {
            _Timmer = _CallInterval;

            if (_Swapper)
            {
                m_UnityActionOne.Invoke();
            }
            else
            {
                m_UnityActionTwo.Invoke();
            }

            _Swapper = !_Swapper; // Change the state         
        }
    }

    private void PrintOne()
    {
        print("Action ONE called");
    }

    private void PrintTwo()
    {
        print("Action TWO called");
    }

    private void PrintSomething() 
    {
        print("Action called");
    }


}
