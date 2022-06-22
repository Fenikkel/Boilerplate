using UnityEngine;

public class ConstantLerpColor : MonoBehaviour
{
    MeshRenderer _ModelMeshRenderer;

    [SerializeField]
    [Range(0f, 1f)]
    float _LerpTime;

    [SerializeField]
    Color[] _MyColor;

    int _ColorIndex;

    float t = 0f;
    
    void Start()
    {
        _ModelMeshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        // Lerp Color
        _ModelMeshRenderer.material.color = Color.Lerp(_ModelMeshRenderer.material.color, _MyColor[_ColorIndex], _LerpTime * Time.deltaTime);


        // Check if it's time to change _ColorIndex
        t = Mathf.Lerp(t, 1f, _LerpTime * Time.deltaTime);

        if (t>.9f)
        {
            t = 0f;
            _ColorIndex++;

            if (_MyColor.Length <= _ColorIndex  )
            {
                _ColorIndex = 0;
            }

        }
    }
}
