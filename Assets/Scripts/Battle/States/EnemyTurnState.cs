using UnityEngine;
using System.Collections;
using System;

public class EnemyTurnState : BattleState
{
    public EnemyTurnState(BattleManager battleManager, BattleStateMachine stateMachine) : base(battleManager, stateMachine)
    { 
    }

    public override void Enter()
    {
        base.Enter();
        battleManager.StartEnemyTurn();

        GameEvents.OnEnemyTurn?.Invoke();
    }
}
