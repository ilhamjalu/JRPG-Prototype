using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [Header("View")]
    [SerializeField] public BattleView battleView;
    [SerializeField] private PanelSkillsManager skillManager;

    [SerializeField] private List<BattleUnit> playerParty;
    [SerializeField] private BattleUnit enemyUnit;

    [SerializeField] private UIAnimation uiAnimation;

    private BattleStateMachine stateMachine;
    private BattleActionExecutor actionExecutor;

    private List<BattleAction> pendingActions = new();

    private BattleUnit currentBattleUnit;
    private int currentBattleUnitIndex;

    public BattleUnit CurrentBattleUnit
    {
        get { return currentBattleUnit; }
        set { currentBattleUnit = value; }
    }

    private void Start()
    {
        stateMachine = new BattleStateMachine(this);
        actionExecutor = new BattleActionExecutor(this, battleView);

        StartBattle();
    }

    private void OnEnable()
    {
        GameEvents.OnSkillSelected += ConfirmAction;
        GameEvents.OnPlayerTurn += ResetCurrentCharacter;
    }

    private void OnDisable()
    {
        GameEvents.OnSkillSelected -= ConfirmAction;
        GameEvents.OnPlayerTurn -= ResetCurrentCharacter;
    }

    private void ResetCurrentCharacter()
    {
        currentBattleUnitIndex = 0;
        currentBattleUnit = playerParty[0];

        skillManager.UpdateSkillsUI(currentBattleUnit);
    }

    private void StartBattle()
    {
        RefreshUI();
        battleView.SetBattleLog($"A wild {enemyUnit.Data.characterName} appeared!");
        stateMachine.Initialize(stateMachine.PlayerTurnState);
        skillManager.UpdateSkillsUI(currentBattleUnit);
    }

    public void ConfirmAction(SkillData skill)
    {
        BattleAction action = new()
        {
            IndexActor = currentBattleUnitIndex,
            Actor = currentBattleUnit,
            Targets = GetTargets(currentBattleUnit, skill),
            Skill = skill
        };

        pendingActions.Add(action);

        NextCharacter();
    }

    private List<BattleUnit> GetTargets(BattleUnit actor, SkillData skill)
    {
        List<BattleUnit> targets = new();

        switch (skill.TargetType)
        {
            case TargetType.Self:
                targets.Add(actor);
                return targets;

            case TargetType.Ally:
                foreach (BattleUnit unit in playerParty)
                {
                    if (unit != actor && !unit.IsDead) targets.Add(unit);
                }
                return targets;

            case TargetType.Enemy:
                targets.Add(enemyUnit);
                return targets;

            default:
                return null;
        }
    }

    private void NextCharacter()
    {
        uiAnimation.PopOut(currentBattleUnitIndex);

        while (true)
        {
            currentBattleUnitIndex++;

            if (currentBattleUnitIndex >= playerParty.Count)
            {
                FinishPlanning();
                return;
            }

            if (!playerParty[currentBattleUnitIndex].IsDead)
                break;
        }

        currentBattleUnit = playerParty[currentBattleUnitIndex];

        skillManager.UpdateSkillsUI(currentBattleUnit);

        uiAnimation.PopIn(currentBattleUnitIndex);
    }

    public bool IsLastCharacter()
    {
        if (currentBattleUnitIndex == playerParty.Count - 1)
        {
            return true;
        }

        return false;
    }

    private void FinishPlanning()
    {
        StartCoroutine(ResolveActions());
        skillManager.ResetSkillsUI();
    }

    private IEnumerator ResolveActions()
    {
        pendingActions = pendingActions.OrderByDescending(x => x.Priority).ToList();

        foreach (BattleAction action in pendingActions)
        {
            yield return ExecuteAction(action);

            if (CheckVictory())
                yield break;
        }

        pendingActions.Clear();

        yield return new WaitForSeconds(1f);

        stateMachine.ChangeState(stateMachine.EnemyTurnState);
    }

    private IEnumerator ExecuteAction(BattleAction action)
    {
        yield return actionExecutor.Execute(action);
    }

    public void StartEnemyTurn()
    {
        StartCoroutine(EnemyTurnRoutine());
    }

    private IEnumerator EnemyTurnRoutine()
    {
        battleView.SetBattleLog($"{enemyUnit.Data.characterName} is thinking...");
    
        BattleAction enemyAction = new()
        {
            Actor = enemyUnit,
            Targets = playerParty,
            Skill = enemyUnit.Data.Skills[0],
            IndexActor = 0
        };
    
        yield return ExecuteAction(enemyAction);
    
        if (CheckDefeat())
            yield break;
    
        stateMachine.ChangeState(stateMachine.PlayerTurnState);
    }

    private bool CheckVictory()
    {
        if (!enemyUnit.IsDead) return false;

        stateMachine.ChangeState(stateMachine.VictoryState);

        return true;
    }

    private bool CheckDefeat()
    {
        if (!playerParty[0].IsDead) return false;

        stateMachine.ChangeState(stateMachine.DefeatState);

        return true;
    }

    public void SetBattleLog(string text)
    {
        battleView.SetBattleLog(text);
    }

    public void RefreshUI()
    {
        battleView.UpdatePlayerHP(playerParty[0].CurrentHP, playerParty[0].Data.maxHP);
        battleView.UpdateSupportHP(playerParty[1].CurrentHP, playerParty[1].Data.maxHP);
        battleView.UpdateEnemyHP(enemyUnit.CurrentHP, enemyUnit.Data.maxHP);
    }
}