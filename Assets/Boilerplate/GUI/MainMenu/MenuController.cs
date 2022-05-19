using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
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
}
