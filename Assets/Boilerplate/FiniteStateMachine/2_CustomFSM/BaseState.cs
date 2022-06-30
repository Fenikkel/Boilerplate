//Plantilla para crear estados. Estos heredaran esta clase.

//Similar a los scripts de la State Machine de Unity
public class BaseState
{
    /*** 2 - CONSTRUCTOR ***/
    
    public string m_StateName;
    protected StateMachine m_StateMachine;

    public BaseState(string name, StateMachine stateMachine)
    {
        m_StateName = name;
        m_StateMachine = stateMachine;
    }
    

    /*** 1 - GAME LOOP **/ 
    
    public virtual void Enter() //Virtual significa que los hijos pueden hacer override
    { 
    }

    public virtual void UpdateLogic() 
    { 
    }

    public virtual void UpdatePhysics()
    {
    }

    public virtual void Exit()
    {
    }
    
}
