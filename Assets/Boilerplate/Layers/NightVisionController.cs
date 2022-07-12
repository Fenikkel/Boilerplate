using UnityEngine;

public class NightVisionController : MonoBehaviour
{
    [Header("Layer")]
    public LayerMask m_NormalVision;
    public LayerMask m_NightVision;

    [Header("Light")]
    public Light m_Light;
    public Color m_NormalColor;
    public Color m_NightColor;

    /*
     
     int tiene 32 bits, por eso hay 32 slots de Layer
    
     & significa AND -> Solo puede dar 1 si la comparación son dos 1.
     | significa OR -> Da uno si uno de los dos bits son 1.
     ~ significa NEGACION -> Da la inversa de lo que tenemos

     */

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Light.color = m_NightColor;

            Camera.main.cullingMask = m_NightVision;
            //ShowLayerMask("Obstacle");
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_Light.color = m_NormalColor;

            Camera.main.cullingMask = m_NormalVision;
            //HideLayerMask("Obstacle");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Toggle("Obstacle");
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowAllLayerMask();
        }
    }

    // Turn on the bit using an OR operation:
    private void ShowLayerMask(string layerName)
    {
        /* Nos da igual si esta a 0 o 1, como hacemos un OR con un 1 siempre dará 1 */
        Camera.main.cullingMask |= 1 << LayerMask.NameToLayer(layerName); // Ej: 1000 | 0010 -> 1010
    }

    // Turn off the bit using an AND operation with the complement of the shifted int:
    private void HideLayerMask(string layerName)
    {
        /* Nos da igual si esta a 0 o 1, como hacemos un AND con un 0 siempre dará 0 */

        /*
         * Obtenemos el LayerMask que queremos -> Todos los bits que no sean de ese layer seran 0 y el bit de nuestro layermask será 1. Ej: 0010
         * Negamos (~) el LayerMask -> Todos los bits se invierten. Ej: 0010 -> 1101
         * Hacemos AND (&) de nuestro LayerMask con el LayerMask de la camara. Todos continua igual menos el bit de layerName. Ej: 0111 & 1101 -> 0101
         */
         
        Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer(layerName));
    }

    // Toggle the bit using a XOR operation:
    private void Toggle(string layerName)
    {
        //The result of XOR is 1 if the two bits are different
        Camera.main.cullingMask ^= 1 << LayerMask.NameToLayer(layerName);
    }

    // Turn on all
    private void ShowAllLayerMask()
    {
        Camera.main.cullingMask = -1; // -1 means "Everything"
    }
}


// https://answers.unity.com/questions/348974/edit-camera-culling-mask.html
