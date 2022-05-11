using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{

    private Image _ProgressBar;

    private void Awake()
    {
        _ProgressBar = transform.GetComponent<Image>();
    }


    private void Update()
    {
        _ProgressBar.fillAmount = Loader.GetLoadingProgress();
    }
}
