using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public GameObject[] m_PuzzleObjects;

    public AudioClip m_MoveClip;
    public AudioClip m_WinClip;

    void Start()
    {
        RestartPuzzle();
    }

    public void PuzzleMove(int move) 
    {
        m_PuzzleObjects[move].SetActive(false);

        bool checkWin = true;

        // Invert
        foreach (GameObject go in m_PuzzleObjects)
        {
            go.SetActive(!go.activeSelf);

            if (!go.activeSelf)
            {
                checkWin = false;
            }
        }

        if (checkWin)
        {
            AudioSource.PlayClipAtPoint(m_WinClip, Vector3.zero);
        }
        else
        {
            AudioSource.PlayClipAtPoint(m_MoveClip, Vector3.zero);
        }     
    }

    private void RestartPuzzle() 
    {
        foreach (GameObject go in m_PuzzleObjects)
        {
            go.SetActive(false);
        }

        int rand = new System.Random().Next(0, m_PuzzleObjects.Length);

        m_PuzzleObjects[rand].SetActive(true);
    }
}
