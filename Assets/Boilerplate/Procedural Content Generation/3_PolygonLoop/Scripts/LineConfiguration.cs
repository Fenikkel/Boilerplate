using UnityEngine;

[CreateAssetMenu(fileName = "LineConfiguration", menuName = "LineRender/Configuration", order = 0)]
public class LineConfiguration : ScriptableObject
{
    [Range(0.01f, 1f)]
    public float lineStartWidth = 0.02f;
    [Range(0.01f, 1f)]
    public float lineEndWidth = 0.02f;

    public Material lineMaterial;
    public Gradient colorGradient;
}
