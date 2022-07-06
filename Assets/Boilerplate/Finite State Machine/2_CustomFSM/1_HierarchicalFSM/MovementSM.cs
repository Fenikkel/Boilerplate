using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public Idle m_IdleState;

    [HideInInspector]
    public Walk m_WalkState;

    [HideInInspector]
    public Jumping m_JumpingState;

    /* Custom variables here */
    public Rigidbody m_RigidBody;
    public float m_Speed = 4.0f;
    public float m_JumpForce = 5.0f;


    public bool _IsGrounded;
    private int _GroundLayer = 6; //1 << 6;

    private void Awake()
    {
        //Initialize the states
        m_IdleState = new Idle(this); // this = referencia de este script "MovementSM"
        m_WalkState = new Walk(this);
        m_JumpingState = new Jumping(this);
    }

    protected override BaseState GetInitialState() //Cogemos el estado en que empezamos
    {
        return m_IdleState;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == _GroundLayer && !_IsGrounded)
        {
            //print("Collision Enter");
            _IsGrounded = true;  
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == _GroundLayer && _IsGrounded)
        {
            //print("Collision Exit");
            _IsGrounded = false;
        }
    }

}
