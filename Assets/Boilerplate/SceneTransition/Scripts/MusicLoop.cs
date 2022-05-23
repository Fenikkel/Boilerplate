using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicLoop : MonoBehaviour
{
    private AudioSource _AudioSource;

    [Header("Singleton")]
    private static MusicLoop _Instance = null; // This value is shared for all MusicLoop instances
    public static MusicLoop Instance
    {
        get 
        { 
            return _Instance; 
        }
    }

    void Awake()
    {
        CheckSingleton();        
    }

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void CheckSingleton() 
    {
        if (_Instance != null && _Instance != this) //If the instance we got is from another
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _Instance = this;
        }

        this.transform.parent = null;   //Unparent for the sake of the DontDestroyOnLoad

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        if (_AudioSource.isPlaying)
        {
            return;
        }

        _AudioSource.Play();
    }

    public void StopMusic()
    {
        _AudioSource.Stop();
    }
}