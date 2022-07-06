using UnityEngine;

[CreateAssetMenu(fileName = "RegularPolygon", menuName = "MathShapes/RegularPolygon", order = 0)]
public class PolygonConfiguration : ScriptableObject
{
    [Header("Polygon Variables")]
    public float circumradius = 5.0f; //Polygon size //Radious of the external circle
    public int numInnerPolygons = 10; //Number of the polygons to draw

    [Range(0.01f, 1.0f)]
    public float lineWidth = 0.1f;

    [Range(1, 10)]
    public int subdivisions = 4;
    /*
     1 -> New point will be in the center of the line (between initial point and final point)
     2 -> New point will be between the first subdivision (center of the line) and the initial point
     3 -> New point will be between the subdivision 2 point and the initial point
     4 -> etc
     */

    [Space]
    public float[] pointPos = new float[] { 0f, 90f, 180f, 270f}; // Remember to close the loop!
    /*
      0º -> Right
    180º -> Left
     90º -> Up
    270º -> Down
    */
}

//https://en.wikipedia.org/wiki/Hexagon
// How to get the points of an Hexagon: https://www.quora.com/How-can-you-find-the-coordinates-in-a-hexagon
