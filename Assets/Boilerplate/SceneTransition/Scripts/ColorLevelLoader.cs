using UnityEngine;

public class ColorLevelLoader : MonoBehaviour
{
    public void LoadRedLevel() 
    {
        Loader.Load(Loader.SceneName.Red);
    }

    public void LoadGreenLevel()
    {
        Loader.Load(Loader.SceneName.Green);
    }

    public void LoadBlueLevel()
    {
        Loader.Load(Loader.SceneName.Blue);
    }
}
