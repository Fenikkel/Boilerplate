using UnityEngine;

public class DelegateHandler : MonoBehaviour
{
     
    public delegate void OnClickDelegate();
    public static OnClickDelegate myDelegate;

    public void TriggerDelegate() 
    {

        //Short way
        //myDelegate?.Invoke();     /* "?" to make the null check */

        //Long way
        if (myDelegate != null)
        {
            myDelegate(); // Send broadcast
        }
    } 
}
