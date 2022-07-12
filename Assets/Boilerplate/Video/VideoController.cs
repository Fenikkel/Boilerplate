using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;


public class VideoController : MonoBehaviour
{
    VideoPlayer _VideoPlayer;

    public VideoClip[] _VideoClips;

    public UnityEvent m_OnPlayVideo;
    public UnityEvent m_OnVideoEnded;

    private void Awake()
    {
        _VideoPlayer = GetComponent<VideoPlayer>();
        Fenikkel.ClearOutRenderTexture(_VideoPlayer.targetTexture); // Clear Residual images

        _VideoPlayer.loopPointReached += OnVideoLoopReached;
    }

    private void OnDestroy()
    {
        if (_VideoPlayer != null)
        {
            Fenikkel.ClearOutRenderTexture(_VideoPlayer.targetTexture); // Clear Residual images when we close the app
        }
    }

    private void OnVideoLoopReached(VideoPlayer vp)
    {
        // Stop video
        StopVideo();

        // Trigger event
        m_OnVideoEnded.Invoke();
        //print("On video ended");
    }

    public void PlayVideo(int index) 
    {
        // Play video
        _VideoPlayer.clip = _VideoClips[index];
        _VideoPlayer.Play();

        // Trigger event
        m_OnPlayVideo.Invoke();
    }

    public void StopVideo()
    {
        _VideoPlayer.Stop();

        // Clear Residual images
        Fenikkel.ClearOutRenderTexture(_VideoPlayer.targetTexture);
    }
}
