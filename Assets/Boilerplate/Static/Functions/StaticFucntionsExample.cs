using UnityEngine;
using UnityEngine.UI;

public class StaticFucntionsExample : MonoBehaviour
{

    public int m_ExampleInteger = 12345;

    public Text m_CurrentIntegerText;
    public Text m_LastDigitText;

    private void Start()
    {
        m_CurrentIntegerText.text = "Current Integer: " + m_ExampleInteger;
    }

    public void ShowTheTail() 
    {
        m_LastDigitText.text = "Last digit: " + Fenikkel.GetLastIntDigit(m_ExampleInteger);
    }

    public void CutTheTail() 
    {
        m_ExampleInteger = Fenikkel.RemoveLastIntDigit(m_ExampleInteger);

        m_CurrentIntegerText.text = "Current Integer: " + m_ExampleInteger;
    }
}
