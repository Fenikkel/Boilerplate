using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonUnityAction : MonoBehaviour
{
    public UnityAction m_UnityAction; // Can't have arguments

    public GameObject m_Target;

    public Button m_ActionButton;
    public Button m_ListenerButton;

    private void OnEnable()
    {
        /* UnityAction way to add functions to a button */
        m_UnityAction = ChangeColor;
        m_UnityAction += ChangeRotation;

        m_ActionButton.onClick.AddListener(m_UnityAction);


        /* Normal way to add functions to a button */
        m_ListenerButton.onClick.AddListener(ChangeColor);
        m_ListenerButton.onClick.AddListener(ChangeRotation);
    }

    void ChangeColor()
    {
        Renderer renderer = m_Target.GetComponentInChildren<Renderer>();
        renderer.material.color = Color.blue;
    }

    void ChangeRotation() 
    {
        m_Target.transform.Rotate(Vector3.up, 30.0f);
    }
}
