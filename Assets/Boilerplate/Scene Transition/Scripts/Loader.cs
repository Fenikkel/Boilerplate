using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader 
{
    private class LoadingMonoBehaviour : MonoBehaviour { } // Dummy class

    public enum SceneName //We need to put the scenes in the same order in the Build window
    {
        Red,
        Green,
        Blue,
        Loading    
    }

    private static Action _OnLoaderCallback; //Action is a delegate that returns void
    private static AsyncOperation _LoadingAsyncOperation;

    public static void Load(SceneName scene) //First we load the Loading scene and after the first frame, we call m_OnLoaderCallback
    { 

        _OnLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object"); //Dummy object, so we can add the dummy class that extends monobehaviour and we can call StartCoroutine
            LoadingMonoBehaviour loadingComponent = loadingGameObject.AddComponent<LoadingMonoBehaviour>(); //Dummy script that extends MonoBehaviour added as a component of a dummy GO in the current scene for use it to call our LoadSceneAsync coroutine

            loadingComponent.StartCoroutine(LoadSceneAsync(scene)); //We can now call the coroutine inside Loader script that doesn't have the MonoBehaviour extension.
        };

        //Stops the current scene and loads the target one.
        //SceneManager.LoadScene(SceneName.Loading.ToString()); //Load with the name
        SceneManager.LoadScene((int)SceneName.Loading);   //Load with the Index

    }

    private static IEnumerator LoadSceneAsync(SceneName scene) {

        //Debug.Log("Previous loading progress: " + GetLoadingProgress());

        yield return null;

        //Load the target scene while the current is still working. When finished, show the level loaded. It should be called by a coroutine, thats why we do all the dummy think, because this class doesn't extend monobehaviour.
        //m_LoadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString()); //Load with the name
        _LoadingAsyncOperation = SceneManager.LoadSceneAsync((int)scene); //Load with the Index

        while (!_LoadingAsyncOperation.isDone)
        {
            Debug.Log("Current loading progress: " + GetLoadingProgress());
            yield return null;
        }
        _LoadingAsyncOperation = null;

        //yield return new WaitForSeconds(4.0f); //BORRAR
    }

    public static float GetLoadingProgress() {

        if (_LoadingAsyncOperation != null)
        {
            return _LoadingAsyncOperation.progress;
        }
        else
        {
            Debug.Log("No Async Operation active");
            return 0f;
        }

    }

    public static void LoaderCallback()
    {
        if (_OnLoaderCallback != null)
        {
            _OnLoaderCallback(); //call
            _OnLoaderCallback = null; //clear
        }
    }
}
