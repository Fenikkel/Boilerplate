using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    public float m_DebugWaitTime = 3.0f;

    private bool _IsFirstUpdate = true;

    private float _Timmer;
    private void Start()
    {
        _Timmer = m_DebugWaitTime;
        System.GC.Collect(); //Call the garbage collector to evade doing this during the game and have some spikes
    }

    private void Update()
    {

        if (_Timmer <= 0)
        {
            if (_IsFirstUpdate)
            {
                _IsFirstUpdate = false;
                Loader.LoaderCallback();
            }
        }
        else
        {
            _Timmer -= Time.deltaTime;
        }

    }
}
