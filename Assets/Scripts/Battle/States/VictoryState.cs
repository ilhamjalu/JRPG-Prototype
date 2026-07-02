using UnityEngine;

public class VictoryState : BattleState
{
    public VictoryState(BattleManager battleManager, BattleStateMachine stateMachine) 
        : base(battleManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        battleManager.SetBattleLog("Victory!");

        battleManager.battleView.ShowPanel(true);

        AudioManager.Instance.PlayVictory();
    }
}
