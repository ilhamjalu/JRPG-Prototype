using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Battle/Heal Skill")]
public class HealSkill : SkillData
{
    public int HealAmount;

    public override void Execute(BattleUnit caster, List<BattleUnit> target)
    {
        foreach (var targetUnit in target)
        {
            targetUnit.Heal(HealAmount);
        }
    }
}