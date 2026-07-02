using UnityEngine;

public abstract class BattleState
{
    protected BattleManager battleManager;
    protected BattleStateMachine stateMachine;

    public BattleState(BattleManager battleManager, BattleStateMachine stateMachine)
    {
        this.battleManager = battleManager;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        Debug.Log($"Entering state: {GetType().Name}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exiting state: {GetType().Name}");
    }
}
