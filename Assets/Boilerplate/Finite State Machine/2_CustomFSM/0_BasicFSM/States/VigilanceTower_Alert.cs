using UnityEngine;

public class VigilanceTower_Alert : BaseState
{
    private float _DistanceBetween; 
    private VigilanceTowerSM _WatchTowerSM;

    //Constructor
    public VigilanceTower_Alert(VigilanceTowerSM stateMachine) : base("Alert", stateMachine) // Llamamos (:) al constructor de BaseState y le pasamos el nombre de el estado
    {
        _WatchTowerSM = stateMachine;
    }


    public override void Enter()
    {
        base.Enter();
        _DistanceBetween = Vector3.Distance(_WatchTowerSM.m_Player.position, _WatchTowerSM.m_WatchTower.position);
        _WatchTowerSM.m_WatchTower.GetComponent<Animator>().SetTrigger("Alert");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _DistanceBetween = Vector3.Distance(_WatchTowerSM.m_Player.position, _WatchTowerSM.m_WatchTower.position);

        if (6.0f < _DistanceBetween)
        {
            _WatchTowerSM.ChangeState(_WatchTowerSM.m_IdleState); //Usamos la funcion ChangeState que hereda de StateMachine
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        base.Exit();
        _WatchTowerSM.m_WatchTower.GetComponent<Animator>().SetTrigger("Idle");
    }
}
