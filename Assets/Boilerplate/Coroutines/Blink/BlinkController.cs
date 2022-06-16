using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlinkController : MonoBehaviour
{
    [Header("Blink")]
    public Image m_BlinkImage;
    [Range(0.0f, 0.5f)]
    public float m_BlinkTime = 0.2f; //Time we stay at blink image
    [Range(0.1f, 0.5f)]
    public float m_BlinkTransitionTime = 0.2f; //Time for fading in and out (each one the same amount)
    private Coroutine m_BlinkCoroutine = null;

    public UnityEvent m_OnStartBlink;
    public UnityEvent m_OnMiddleBlink;
    public UnityEvent m_OnEndBlink;

    public void Blink()
    {
        if (m_BlinkCoroutine != null)
        {
            StopCoroutine(m_BlinkCoroutine);
        }

        m_BlinkCoroutine = StartCoroutine(BlinkCoroutine());
    }

    IEnumerator BlinkCoroutine()
    {
        m_OnStartBlink.Invoke();

        //BLINK IN (fade from transparent to opaque)
        float alpha = 0;
        for (float i = 0; i <= m_BlinkTransitionTime; i += Time.deltaTime)
        {
            alpha = (i - 0) / (m_BlinkTransitionTime - 0); //Normalize value between 0 and 1

            // set color with i as alpha
            m_BlinkImage.color = new Color(m_BlinkImage.color.r, m_BlinkImage.color.g, m_BlinkImage.color.b, alpha);
            yield return null;
        }
        m_BlinkImage.color = new Color(m_BlinkImage.color.r, m_BlinkImage.color.g, m_BlinkImage.color.b, 1); // fix residual values

        //MIDDLE EVENT
        m_OnMiddleBlink.Invoke();
        yield return new WaitForSeconds(m_BlinkTime);

        //BLINK OUT (fade from opaque to transparent)
        for (float i = m_BlinkTransitionTime; i >= 0; i -= Time.deltaTime)
        {
            alpha = (i - 0) / (m_BlinkTransitionTime - 0); //Normalize value between 0 and 1

            // set color with i as alpha
            m_BlinkImage.color = new Color(m_BlinkImage.color.r, m_BlinkImage.color.g, m_BlinkImage.color.b, alpha);
            yield return null;
        }
        m_BlinkImage.color = new Color(m_BlinkImage.color.r, m_BlinkImage.color.g, m_BlinkImage.color.b, 0); // fix residual values

        m_OnEndBlink.Invoke();

        //Close coroutine
        m_BlinkCoroutine = null;

    }
}
