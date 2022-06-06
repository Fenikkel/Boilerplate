using UnityEngine;

public class StaticVariableExample : MonoBehaviour
{
    public static int m_StaticInt;

    public int m_NormalInt;



    public void SetValues(int value) 
    {
        m_StaticInt = value;
        m_NormalInt = value;
    }

    public void PrintValues() 
    {
        Debug.Log("Static: " + m_StaticInt + "\n" + "Normal: " + m_NormalInt);
    }
}
