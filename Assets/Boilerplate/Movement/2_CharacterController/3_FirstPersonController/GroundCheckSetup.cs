using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckSetup : MonoBehaviour
{
    //GroundCheck must be a child GameObject of the GameObject with the CharacterController component
    public CharacterController m_CharacterController;
    void Awake()
    {
        //Center point of the Character controller - Height/2  
        //Character width doen't matter here
        transform.localPosition = m_CharacterController.center - Vector3.up * m_CharacterController.height / 2;
    }
}
