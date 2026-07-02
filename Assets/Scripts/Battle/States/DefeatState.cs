using UnityEngine;

public class DefeatState : BattleState
{
    public DefeatState(BattleManager battleManager, BattleStateMachine stateMachine) 
        : base(battleManager, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        battleManager.SetBattleLog("Defeat...");
        battleManager.battleView.ShowPanel(false);
        AudioManager.Instance.PlayDefeat();
    }
}
