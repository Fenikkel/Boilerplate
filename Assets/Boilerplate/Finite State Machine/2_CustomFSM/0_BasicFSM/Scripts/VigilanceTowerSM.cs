using UnityEngine;

public class VigilanceTowerSM : StateMachine
{
    [HideInInspector]
    public VigilanceTower_Idle m_IdleState;

    [HideInInspector]
    public VigilanceTower_Alert m_AlertState;

    /* Custom variables here */
    public Transform m_Player;
    public Transform m_WatchTower;

    private void Awake()
    {
        //Initialize the states
        m_IdleState = new VigilanceTower_Idle(this); // this = referencia de este script "WatchTowerSM"
        m_AlertState = new VigilanceTower_Alert(this);
    }

    protected override BaseState GetInitialState() //Cogemos el estado en que empezamos
    {
        return m_IdleState;
    }

}
