using UnityEngine;

public class AnotherRandomScript : MonoBehaviour
{
    void Start()
    {
        SimpleUnityAction.m_UnityActionOne += PrintCaracola;
        //SimpleUnityAction.m_UnityActionOne = null;
    }

    public void PrintCaracola() 
    {
        print("CARACOLA");
    }
}
