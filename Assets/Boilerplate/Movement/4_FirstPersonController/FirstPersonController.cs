using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Transform m_PlayerCamera;

    [Header("Movement")]
    public float m_Speed = 6.0f;
    public float m_Gravity = -9.81f;

    [Header("Ground Check")]
    public Transform m_GroundCheck;
    public float m_GroundSphereArea = 0.4f; //Ground Check Sphere Area
    public LayerMask m_GroundMask;

    [Header("Jump")]
    public float m_JumpHeight = 1.0f;

    [Header("Vision")]
    public bool m_InvertY = false;
    public float m_MouseSensitivity = 300f;


    /* Private */
    Vector3 _Velocity;
    bool _IsGrounded;

    float _InputX = 0.0f;
    float _InputZ = 0.0f;
    Vector3 _MovementStep = Vector3.zero;




    float _xRotation = 0.0f; //Initial rotation
    float _MouseX = 0.0f;
    float _MouseY = 0.0f;

    private CharacterController _CharacterController;

    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        JumpAndGravity();
        GroundedCheck();
        Movement();
        CheckMouse();
    }

    #region MOVEMENT
    void JumpAndGravity() 
    {
        if (Input.GetButtonDown("Jump") && _IsGrounded)
        {
            //Jump formula -> JumpVelocity =  √(JumpHeight * -2.0 * Gravity)
            _Velocity.y = Mathf.Sqrt(m_JumpHeight * -2.0f * m_Gravity);

        }

        //Gravity formula -> Y = 1/2 * Gravity * Time^2
        _Velocity.y += m_Gravity * Time.deltaTime;
        _CharacterController.Move(_Velocity * Time.deltaTime);
    }

    void GroundedCheck() 
    {
        _IsGrounded = Physics.CheckSphere(m_GroundCheck.position, m_GroundSphereArea, m_GroundMask);

        if (_IsGrounded && _Velocity.y < 0.0f)
        {
            _Velocity.y = -0.2f; //Si ponemos un valor menor de 0.0f, nos aseguramos que si queda un trozo por llegar al suelo, este sera completado y no quedará el jugador flotando.
        }
    }

    void Movement()
    {
        //Input Movement
        _InputX = Input.GetAxis("Horizontal");
        _InputZ = Input.GetAxis("Vertical");

        _MovementStep = transform.right * _InputX + transform.forward * _InputZ;

        _CharacterController.Move(_MovementStep * m_Speed * Time.deltaTime);
    }

    #endregion

    #region VISION
    private void CheckMouse() //"Bug": if we press play and move the mouse before the game starts, the camera looks at down
    {
        _MouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity * Time.deltaTime;
        _MouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity * Time.deltaTime;

        if (m_InvertY)
        {
            _xRotation += _MouseY;
        }
        else
        {
            _xRotation -= _MouseY;
        }

        _xRotation = Mathf.Clamp(_xRotation, -90.0f, 90.0f);

        m_PlayerCamera.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * _MouseX); //Mouse X is 0.0 when is quiet. So when we move, we get values like 0.09
    }

    public void LookAt(Vector3 lookPos)
    {
        _xRotation = Mathf.Clamp(-lookPos.x, -90.0f, 90.0f);

        if (m_InvertY)
        {
            _xRotation = -_xRotation;
        }

        m_PlayerCamera.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        transform.eulerAngles = Vector3.up * lookPos.y; //For rotation seems that we dont need to enable and disable CharacterController component
    }

    #endregion

    #region TELEPORT
    public void Teleport(Transform telePoint)
    {
        _CharacterController.enabled = false;
        transform.position = telePoint.position - _CharacterController.center + Vector3.up * (_CharacterController.height / 2 + _CharacterController.skinWidth);
        _CharacterController.enabled = true;

        LookAt(telePoint.eulerAngles);
    }

    #endregion
}
