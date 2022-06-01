using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField]
    private Text _VolumeTextValue = null;    
    [SerializeField]
    private Slider _VolumeSlider = null;
    [SerializeField]
    private float _DefaultVolume = 0.5f;

    [SerializeField]
    private GameObject _ConfirmationPrompt = null;

    [Header("Levels To Load")]
    public string m_NewGameLevel;

    [SerializeField] 
    private GameObject _NoSavedGameDialog = null;
    private string _LevelToLoad;

    public void Start() 
    {  
        //LOAD PLAYER PREFS
        //AudioListener.volume = PlayerPrefs.GetFloat("masterVolume");
        //_VolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        //_VolumeTextValue.text = PlayerPrefs.GetFloat("masterVolume").ToString("0.0");
    }

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
        _VolumeTextValue.text = volume.ToString("0.0"); //One decimal format
    }

    public void VolumeApply() 
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);

        //Show prompt
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType) 
    {

        if (MenuType == "Audio")
        {
            AudioListener.volume = _DefaultVolume;
            _VolumeSlider.value = _DefaultVolume;
            _VolumeTextValue.text = _DefaultVolume.ToString("0.0");
            VolumeApply(); //Save to PlayerPref
        }
    }

    public IEnumerator ConfirmationBox() 
    {
        _ConfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        _ConfirmationPrompt.SetActive(false);
    }
}
