using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DobleTapManager : MonoBehaviour, IPointerClickHandler
{
    public float m_DobleClickMaxTime = 0.75f;

    public UnityEvent m_OnDobleClick;

    float _LastTimeClick;
    float _CurrentTimeClick;



    /*This script must be attached to the element you want to be double tappable*/
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");

        _CurrentTimeClick = eventData.clickTime;

        if (Mathf.Abs(_CurrentTimeClick - _LastTimeClick) < m_DobleClickMaxTime) // Double-click happened
        {         
            //Debug.Log("Double click");
            m_OnDobleClick.Invoke();
        }

        _LastTimeClick = _CurrentTimeClick;
    }

}
