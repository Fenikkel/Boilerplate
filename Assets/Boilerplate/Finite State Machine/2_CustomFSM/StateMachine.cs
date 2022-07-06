using UnityEngine;

public class StateMachine : MonoBehaviour
{
    /*** 1 - OBTENEMOS EL ESTADO QUE QUEREMOS USAR***/
    
    BaseState _CurrentState;

    void Start()
    {
        _CurrentState = GetInitialState();

        if (_CurrentState != null) 
        {
            _CurrentState.Enter();
        }
    }
    

    /*** 4 - HACEMOS FUNCIONAR EL LOOP DEL ESTADO ACTUAL ***/
    
    void Update()
    {
        if (_CurrentState != null)
        {
            _CurrentState.UpdateLogic();
        }
    }

    private void LateUpdate()
    {
        if (_CurrentState != null)
        {
            _CurrentState.UpdatePhysics();
        }
    }
    

    /*** 5 - CAMBIAMOS EL ESTADO ***/
    
    public void ChangeState(BaseState newState) 
    {
        _CurrentState.Exit(); //Salimos del estado actual
        _CurrentState = newState; //Asignamos el nuevo estado
        _CurrentState.Enter(); //Entramos al nuevo estado
    }
    

    /*** 2 - DEVOLVEMOS EL ESTADO CON EL QUE QUEREMOS EMPEZAR ***/
    
    protected virtual BaseState GetInitialState() 
    {
        return null;
    }
    

    /*** 3 - MOSTRAMOS EN PANTALLA QUE ESTADO ESTAMOS USANDO ***/
    
    private void OnGUI()
    {
        string content;

        if (_CurrentState != null)
        {
            content = _CurrentState.m_StateName;
        }
        else 
        {
            content = "(no current state)";
        }

        GUILayout.Label($"<color='black'><size=40>{content}</size></color>"); //No spaces allowed in tags
    }
    
}
