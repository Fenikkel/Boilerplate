using UnityEngine;

public class VigilanceTower_Idle : BaseState
{
    private float _DistanceBetween;
    private VigilanceTowerSM _WatchTowerSM;

    //Constructor
    public VigilanceTower_Idle(VigilanceTowerSM stateMachine) : base("Idle", stateMachine) // Llamamos (:) al constructor de BaseState y le pasamos el nombre de el estado.
    { 
        _WatchTowerSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _DistanceBetween = Vector3.Distance(_WatchTowerSM.m_Player.position, _WatchTowerSM.m_WatchTower.position);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        _DistanceBetween = Vector3.Distance(_WatchTowerSM.m_Player.position, _WatchTowerSM.m_WatchTower.position);

        if (_DistanceBetween < 5.0f)
        {
            _WatchTowerSM.ChangeState(_WatchTowerSM.m_AlertState); //Usamos la funcion ChangeState que hereda de StateMachine
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
