using UnityEngine;
using UnityEngine.UI;


public class MobileCam : MonoBehaviour
{

    public RawImage m_CamImage;
    public bool m_FrontFacing;

    private WebCamTexture m_WebCameraTexture;

    void Start()
    {
        InitCamera();
    }

    private void InitCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.Log("There is no cam active");
            return;
        }

        WebCamDevice currentDevice;

        for (int i = 0; i < devices.Length; i++)
        {
            currentDevice = devices[i];

            if (currentDevice.isFrontFacing == m_FrontFacing) //Get the desired camera. Front or rear.
            {
                //m_WebCameraTexture = new WebCamTexture(); // Use the first camera founded
                m_WebCameraTexture = new WebCamTexture(currentDevice.name); // Use the specified camera
                //m_WebCameraTexture = new WebCamTexture(currentDevice.name, Screen.width, Screen.height);

                Debug.Log("Using: " + currentDevice.name);
                break;
            }
        }

        if (m_WebCameraTexture == null)
        {
            Debug.Log("Camera not found");
            return;
        }


        m_CamImage.texture = m_WebCameraTexture; // Set the texture

        m_WebCameraTexture.autoFocusPoint = null; //Putting this to null, ENABLES the continuous autofocus
        m_WebCameraTexture.Play();

    }

    private void OnDestroy()
    {
        if (m_WebCameraTexture != null)
        {
            m_WebCameraTexture.Stop();
        }

    }
}
