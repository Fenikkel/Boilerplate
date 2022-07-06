using UnityEngine;

/*Grounded sera un intermediario entre la maquina de estado y los estados. Sera un grupo de estados (como una carpeta)*/
public class Grounded : BaseState
{
    protected MovementSM _MovementSM; //Los estados hijos de Grounded podran usar _MovementSM al ser "protected"
    private bool _Grounded;

    //Constructor
    public Grounded(string stateName, MovementSM stateMachine) : base(stateName, stateMachine) // Llamamos (:) al constructor de BaseState y le pasamos el nombre de el estado del hijo
    {
        _MovementSM = stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            m_StateMachine.ChangeState(_MovementSM.m_JumpingState); //Si estamos en tierra pasamos al Idle
        }
    }
}
