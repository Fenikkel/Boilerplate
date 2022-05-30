using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField]
    private Text volumeTextValue = null;    
    [SerializeField]
    private Slider volumeSlider = null;

    [Header("Levels To Load")]
    public string m_NewGameLevel;

    [SerializeField] 
    private GameObject _NoSavedGameDialog = null;
    private string _LevelToLoad;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(m_NewGameLevel);
    }

    public void LoadGameDialogYes() 
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            _LevelToLoad = PlayerPrefs.GetString("SavedLevel");
            //PlayerPrefs.SetString("SavedLevel", "LevelNameOrIndex?"); //How to save parametters in PlayerPrefs

            SceneManager.LoadScene(_LevelToLoad);
        }
        else
        {
            _NoSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton() 
    {
        Application.Quit();
    }

    public void SetVolume(float volume) 
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0"); //One decimal format
    }

    public void VolumeApply() 
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //Show prompt
    }

    public IEnumerator ConfirmationBox() 
    {
        //https://www.youtube.com/watch?v=Cq_Nnw_LwnI&t=1288s
        yield return new WaitForSeconds(2.0f);
    }
}
