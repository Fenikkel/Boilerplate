using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleUnityEvent : MonoBehaviour
{
    public UnityEvent m_UnityEventOne;
    public UnityEvent m_UnityEventTwo;

    private float _CallInterval = 1.0f;  
    private float _Timmer = 0.0f;

    private bool _Swapper = true;

    private void Start()
    {
        m_UnityEventOne.AddListener(PrintOne);

        m_UnityEventTwo.AddListener(PrintTwo);
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
                m_UnityEventOne.Invoke();
            }
            else
            {
                m_UnityEventTwo.Invoke();
            }

            _Swapper = !_Swapper; // Change the state         
        }
    }

    private void PrintOne() 
    {
        print("One called");
    }

    private void PrintTwo()
    {
        print("Two called");
    }
}
