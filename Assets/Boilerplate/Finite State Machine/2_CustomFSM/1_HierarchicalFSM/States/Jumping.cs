using UnityEngine;

/*Grounded sera un intermediario entre la maquina de estado y los estados. Sera un grupo de estados (como una carpeta)*/
public class Jumping : BaseState
{
    protected MovementSM _MovementSM; //Los estados hijos de Grounded podran usar _MovementSM al ser "protected"

    //Constructor
    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine) // Llamamos (:) al constructor de BaseState y le pasamos el nombre de el estado del hijo
    {
        _MovementSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        Vector3 vel = _MovementSM.m_RigidBody.velocity;
        vel.y = _MovementSM.m_JumpForce;
        _MovementSM.m_RigidBody.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (_MovementSM._IsGrounded && _MovementSM.m_RigidBody.velocity.y < Mathf.Epsilon) // Si esta tocando tierra y ademas esta quieto...
        {
            m_StateMachine.ChangeState(_MovementSM.m_IdleState);
        }
    }
}
