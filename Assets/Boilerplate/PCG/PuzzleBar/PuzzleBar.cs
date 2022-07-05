using UnityEngine;

public class PuzzleBar : MonoBehaviour
{
    public RectTransform m_Container;
    public RectTransform m_GreenArea;
    public RectTransform m_Arrow;

    [Header("Sounds")]
    [SerializeField]
    AudioClip _SolvedClip;
    [SerializeField]
    AudioClip _FailedClip;

    float _ArrowSpeed = 1.0f;
    float _ArrowBounds;

    float _ArrowPosX;

    bool _Active = true;

    float _Timmer;

    void Start()
    {
        _ArrowBounds = m_Container.sizeDelta.x / 2.0f;
        //print("Arrow Bounds: " + arrowBounds);

        RandomizePuzzle();
    }

    void Update()
    {
        if (_Active)
        {
            MoveArrow();

            if (Input.GetKeyDown(KeyCode.Space)) // fire
            {
                CheckSolution();
                _Active = false;
            }
        }
        else  
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Esta repetición se soluciona con StateMachines
            { 
                _Active = true;
                RandomizePuzzle();
            }

        }
    }

    private void MoveArrow()
    {
        _Timmer += Time.deltaTime;

        _ArrowPosX = Mathf.Sin(_Timmer * _ArrowSpeed); // From -1f to 1f
        _ArrowPosX = _ArrowPosX * _ArrowBounds;

        m_Arrow.localPosition = new Vector3(_ArrowPosX, m_Arrow.localPosition.y, m_Arrow.localPosition.z);
    }

    private void CheckSolution()
    {
        float solutionBounds = m_GreenArea.sizeDelta.x / 2.0f;

        if (-solutionBounds <= _ArrowPosX && _ArrowPosX <= solutionBounds)
        {
            print("Solved");
            AudioSource.PlayClipAtPoint(_SolvedClip ,Camera.main.transform.position);
        }
        else
        {
            AudioSource.PlayClipAtPoint(_FailedClip, Camera.main.transform.position);
            print("Failed");
        }
    }
    private void RandomizePuzzle()
    {
        _ArrowSpeed = Random.Range(0.5f, 10f);
        m_GreenArea.sizeDelta = new Vector2(Random.Range(10f, m_Container.sizeDelta.x / 2f), m_GreenArea.sizeDelta.y);

        _Timmer = 0;
    }
}
