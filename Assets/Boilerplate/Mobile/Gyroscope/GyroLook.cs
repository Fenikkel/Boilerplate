using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroLook : MonoBehaviour
{
    Gyroscope m_Gyro;
    Quaternion m_RotFix;
    public Transform m_Camera;
    GameObject m_CameraParent;

    private void Awake()
    {
        if (GyroEnabled())
        {
            Debug.Log("Gyro Started");
        }
        else 
        {
            Debug.LogWarning("This device don't have a gyroscope");
        }
    }

    void Update()
    {
        //transform.rotation = Input.gyro.attitude;

        m_RotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        m_Camera.localRotation = m_RotFix;
    }

    private bool GyroEnabled()
    {
        if (SystemInfo.supportsGyroscope)
        {
            // Create a parent object containing the camera (you could do this manually in the 
            // hierarchy if preferred, or here in code)
            m_CameraParent = new GameObject("CamParent");
            m_CameraParent.transform.position = m_Camera.position;
            m_Camera.parent = m_CameraParent.transform;

            // Rotate the parent object by 90 degrees around the x axis
            m_CameraParent.transform.Rotate(Vector3.right, 90);

            m_Gyro = Input.gyro;
            m_Gyro.enabled = true;
            return true;
        }

        return false;
    }
}
