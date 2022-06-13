using UnityEngine;
using UnityEngine.Events;

public class PuzzleButtonTrigger : MonoBehaviour
{
    public UnityEvent OnEnterArea;
    public UnityEvent OnExitArea;

    private void OnTriggerEnter(Collider other)
    {
        OnEnterArea.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExitArea.Invoke();
    }
}
