using UnityEngine;

public class BattleStateMachine
{
    private BattleState currentState;

    public PlayerTurnState PlayerTurnState { get; private set; }
    public EnemyTurnState EnemyTurnState { get; private set; }
    public VictoryState VictoryState { get; private set; }
    public DefeatState DefeatState { get; private set; }

    public BattleStateMachine(BattleManager battleManager)
    {
        PlayerTurnState = new PlayerTurnState(battleManager, this);
        EnemyTurnState = new EnemyTurnState(battleManager, this);
        VictoryState = new VictoryState(battleManager, this);
        DefeatState = new DefeatState(battleManager, this);
    }

    public void Initialize(BattleState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(BattleState newState)
    {
        if (currentState == newState) return;

        Debug.Log(currentState.ToString());

        currentState.Exit();
        currentState = newState;
        currentState.Enter();

        Debug.Log(currentState.ToString());
    }
}
