using UnityEngine;

public class SinusoidalSize : MonoBehaviour
{
    [SerializeField]
    private float _Time = 0.0f; // Time that has passed in the sinusoidal wave

    private float _SizeValue = 0.0f;
    private Vector3 _SizeVector = Vector3.zero;

    private void Start()
    {
        // Set the initial value in case it's not the same
        ChangeSize();
    }

    void Update()
    {
        // Increase the time that has passed
        _Time += Time.deltaTime;

        // Change size between 0.0f and 1.0f
        ChangeSize();
    }

    private void ChangeSize() 
    {
        // Calculate the new size value
        _SizeValue = Mathf.Sin(_Time);

        // Convert negative velues into positives values
        _SizeValue = Mathf.Abs(_SizeValue);

        //print(_SizeValue);

        _SizeVector.x = _SizeValue;
        _SizeVector.y = _SizeValue;
        _SizeVector.z = _SizeValue;

        // Apply the new size 
        this.transform.localScale = _SizeVector;
    }
}
