using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MiPokemon", menuName = "Cartas/Pokemon", order = 0)]
public class CartaPokemon : ScriptableObject
{
    public string nombre = "Nombre Pokemon";
    public string descripcion = "Nombre Pokemon";
    public Color rareza = Color.blue;
    public Sprite arte;
}

