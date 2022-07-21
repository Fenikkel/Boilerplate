using System.Collections;
using UnityEngine;

public class PolygonDrawer : MonoBehaviour
{
    public PolygonConfiguration m_PolygonConfig;
    public LineConfiguration m_LineConfiguration;

    [Header("Draw Mode")]
    public bool m_DrawLineByLine = true;
    [Range(0f, 0.01f)]
    public float m_DrawDelay = 0.0005f;

    GameObject _PolygonsFolder;
    GameObject _ObjectToSpawn;

    Coroutine _DrawCoroutine;

    void Start()
    {
        CreatePolygonLoop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Randomize();
        }
    }

    #region Polygon

    private void CreatePolygonLoop()
    {
        if (_DrawCoroutine != null)
        {
            StopCoroutine(_DrawCoroutine);
            Destroy(_PolygonsFolder);
        }

        StartCoroutine(DrawPolygons());
    }

    IEnumerator DrawPolygons()
    {
        Vector3[] polygonPoints = new Vector3[m_PolygonConfig.pointPos.Length];
        Vector3[] neighbourPoints = new Vector3[m_PolygonConfig.pointPos.Length];

        for (int i = 0; i < polygonPoints.Length; i++)
        {
            polygonPoints[i] = GetPointOfCircle(m_PolygonConfig.circumradius, m_PolygonConfig.pointPos[i]);
        }

        LineRenderer currentLineRenderer;

        _PolygonsFolder = new GameObject("Hexagon's folder");

        for (int i = 0; i < m_PolygonConfig.numInnerPolygons; i++)
        {

            _ObjectToSpawn = new GameObject("Hexagon " + i);
            _ObjectToSpawn.transform.parent = _PolygonsFolder.transform;

            /* Create and set the new line renderer */
            currentLineRenderer = _ObjectToSpawn.AddComponent<LineRenderer>();
            currentLineRenderer.material = m_LineConfiguration.lineMaterial;
            currentLineRenderer.colorGradient = m_LineConfiguration.colorGradient;
            currentLineRenderer.positionCount = 0;
            currentLineRenderer.startWidth = m_LineConfiguration.lineStartWidth;
            currentLineRenderer.endWidth = m_LineConfiguration.lineEndWidth;
            currentLineRenderer.useWorldSpace = false;


            /* DrawHexagon */
            yield return new WaitForSeconds(m_DrawDelay);

            for (int j = 0; j < polygonPoints.Length; j++)
            {
                currentLineRenderer.positionCount++; // Set number of vertices
                currentLineRenderer.SetPosition(j, polygonPoints[j]);


                if (m_DrawLineByLine)
                {
                    yield return new WaitForSeconds(m_DrawDelay);
                }
            }

            /* Close the polygon loop */
            currentLineRenderer.positionCount++;
            currentLineRenderer.SetPosition(polygonPoints.Length, polygonPoints[0]);



            /* Get the neighbour points */
            /*
            for (int a = 0; a < polygonPoints.Length - 1; a++)
            {
                neighbourPoints[a] = polygonPoints[a + 1]; // we set the point at her right
            }
            neighbourPoints[polygonPoints.Length - 1] = polygonPoints[0];
            */

            
            for (int a = polygonPoints.Length - 1; 0 < a; a--)
            {
                neighbourPoints[a] = polygonPoints[a - 1]; // we set the point at her right
            }
            neighbourPoints[0] = polygonPoints[polygonPoints.Length - 1];


            /* Get the points for the inner polygon depending on how many subdivisions we want */
            for (int a = 0; a < polygonPoints.Length; a++)
            {
                neighbourPoints[a] = Vector3.Lerp(polygonPoints[a], neighbourPoints[a], 1f / Mathf.Pow(2f, m_PolygonConfig.subdivisions));
            }

            for (int b = 0; b < polygonPoints.Length; b++)
            {
                polygonPoints[b] = neighbourPoints[b];
            }
        }
    }

    #endregion

    public Vector2 GetPointOfCircle(float radius, float degreePos)
    {
        /*
          0º -> Right
        180º -> Left
         90º -> Up
        270º -> Down
         */

        return new Vector2(radius * Mathf.Cos(degreePos * Mathf.Deg2Rad), radius * Mathf.Sin(degreePos * Mathf.Deg2Rad)); // Convert to degrees -> Mathf.Deg2Rad = Mathf.PI / 180f
    }

    public void Randomize() 
    {

        Destroy(_PolygonsFolder);

        m_PolygonConfig = (PolygonConfiguration)ScriptableObject.CreateInstance("PolygonConfiguration");

        m_PolygonConfig.circumradius = 5.0f;
        m_PolygonConfig.numInnerPolygons = Random.Range(2, 50);
        m_PolygonConfig.subdivisions = Random.Range(1, 11);
        m_PolygonConfig.lineWidth = 0.334f;

        int numPoints = Random.Range(3, 8);

        float[] pointPos = new float[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            pointPos[i] = Random.Range(0f, 360f);
        }
        
        System.Array.Sort(pointPos); // Sort if you want to make polygons, comment if you want random shit

        m_PolygonConfig.pointPos = pointPos;

        CreatePolygonLoop();
    }
}
