using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolationExample : MonoBehaviour
{
    public Transform m_RepeatTarget;
    public Transform m_PingPongTarget;
    
    public Transform m_LerpTarget;
    public Transform m_SmoothStepTarget;

    float _Step;

    float _SizeValue;

    float _Velocity = 0.63f;

    void Update()
    {
        /* REPEAT */
        // From 0 to value

        _SizeValue = Mathf.Repeat(Time.time * _Velocity, 1.0f);
        m_RepeatTarget.localScale = new Vector3(_SizeValue, _SizeValue, _SizeValue);

        /* PING PONG */
        // From 0 to value and viceversa

        _SizeValue = Mathf.PingPong(Time.time * _Velocity, 1.0f);
        m_PingPongTarget.localScale = new Vector3(_SizeValue, _SizeValue, _SizeValue);



        /*
         * Time.time    ->  Goes from 0 to infinite  ->  print(Time.time);
         * Mathf.Sin()  ->  Return values between -1.0f and 1.0f. From -1 to 1 and viceversa
         * Mathf.Abs()  ->  Convert negative values into positive values
         */

        _Step = Mathf.Sin(Time.time);
        _Step = Mathf.Abs(_Step);

        /* LERP */
        // From 0 to value and viceversa, linear (but in this case, we are using a Sine wave that smooth a bit)
        _SizeValue = Mathf.Lerp(0.0f, 1.0f, _Step);

        m_LerpTarget.localScale =  new Vector3(_SizeValue, _SizeValue, _SizeValue);

        /* SMOOTH STEP */
        // From 0 to value and viceversa, but smoothed
        _SizeValue = Mathf.SmoothStep(0.0f, 1.0f, _Step);

        m_SmoothStepTarget.localScale = new Vector3(_SizeValue, _SizeValue, _SizeValue);



    }
}
