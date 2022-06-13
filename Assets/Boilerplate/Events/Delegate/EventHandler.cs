using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public delegate void OnPressEvent(float value);    
    public static event OnPressEvent myEvent;

    public void TriggerEvent()
    {
        //Short way
        //myEvent?.Invoke(0.2f);    /* "?" to make the null check */

        //Long way
        if (myEvent != null)
        {
            myEvent(0.5f); // Send broadcast
        }
    }
}
