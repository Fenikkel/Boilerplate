using UnityEngine;
using UnityEngine.UI;

public class IniciadorCarta : MonoBehaviour
{
    public CartaPokemon m_ScriptableObject;

    public Image m_BackgroundImg;
    public Image m_ArtImg;
    public Text m_NameTxt;
    public Text m_DescriptionTxt;

    void Start()
    {
        m_NameTxt.text = m_ScriptableObject.nombre;
        m_DescriptionTxt.text = m_ScriptableObject.descripcion;
        m_BackgroundImg.color = m_ScriptableObject.rareza;
        m_ArtImg.sprite = m_ScriptableObject.arte;
    }
}
