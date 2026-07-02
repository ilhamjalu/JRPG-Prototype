using UnityEngine;

public class PlayerTurnState : BattleState
{
    public PlayerTurnState(BattleManager battleManager, BattleStateMachine stateMachine) 
        : base(battleManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        battleManager.SetBattleLog("Your Turn");

        GameEvents.OnPlayerTurn?.Invoke();
    }
}
