using UnityEngine;

public class Idle : Grounded
{
    private float _HorizontalInput;

    //Constructor
    public Idle(MovementSM stateMachine) : base("Idle", stateMachine) // Llamamos (:) al constructor de BaseState y le pasamos el nombre de el estado y la maquina de estado
    { 
    }

    public override void Enter()
    {
        base.Enter();
        _HorizontalInput = 0.0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic(); // Hace el Update Logic de Grounded

        _HorizontalInput = Input.GetAxis("Horizontal");
        //_HorizontalInput = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(_HorizontalInput) > Mathf.Epsilon) //Es como decir mayor que 0
        {
            _MovementSM.ChangeState(_MovementSM.m_WalkState); //Usamos la funcion ChangeState que hereda de StateMachine
        }
    }
}
