using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JokeTeller : MonoBehaviour
{
    public GameObject m_TrollImage;
    public Text m_JokeTxt;

    public string m_Solution = "GAMBERRA";

    public void CoroutineTriggerer() 
    {
        /* 
         * If you don't check if it's null, you can press multiple times the button 
         * and have strange behaviours like multiple solution letters repeated
         */

        StartCoroutine(Joke());
    }

    IEnumerator Joke() 
    {
        m_JokeTxt.text = "¿Que es una gamba tirando piedras?";

        // Wait until we press space
        yield return new WaitUntil( ()=> Input.GetKeyDown(KeyCode.Space)); // remember the ()=> before the condition

        m_JokeTxt.text = "Una: ";

        // Show a character of the solution every a quarter of a second
        for (int i = 0; i < m_Solution.Length; i++)
        {
            yield return new WaitForSeconds(0.25f);
            m_JokeTxt.text += m_Solution[i];
        }

        // Wait a second and play the song
        yield return new WaitForSeconds(1.0f);

        GetComponent<AudioSource>().Play();
        m_TrollImage.SetActive(true);
    }
}
