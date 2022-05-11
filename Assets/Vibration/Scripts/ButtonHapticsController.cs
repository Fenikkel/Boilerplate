using UnityEngine;

public class ButtonHapticsController : MonoBehaviour
{
    public void ShortVibration() 
    {
        Vibration.Vibrate(100);
    }

    public void LongVibration()
    {
        Vibration.Vibrate(1000);
    }

}
