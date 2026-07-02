using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionExecutor
{
    private readonly BattleManager battleManager;
    private readonly BattleView battleView;

    public BattleActionExecutor(BattleManager battleManager, BattleView battleView)
    {
        this.battleManager = battleManager;
        this.battleView = battleView;
    }

    public IEnumerator Execute(BattleAction action)
    {
        BattleUnit actor = action.Actor;
        List<BattleUnit> targets = action.Targets;
        SkillData skill = action.Skill;

        battleView.SetBattleLog($"{actor.Data.characterName} uses {skill.SkillName}");
        actor.avatar.ShowSkill(skill.CastLine);

        actor.PlayAttackAnimation();

        AudioManager.Instance.PlaySfx(skill.Sfx);

        yield return actor.skillAnimationController.PlaySkillEffect(skill.animation, skill.EffectAnchorType);

        skill.Execute(actor, targets);

        battleManager.RefreshUI();

        foreach (BattleUnit target in targets)
        {
            yield return target.WaitUntilDeathAnimationFinished();
        }

        yield return new WaitForSeconds(0.5f);
    }
}