using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Battle/Attack Skill")]
public class AttackSkill : SkillData
{
    public int attackPower;

    public override void Execute(BattleUnit caster, List<BattleUnit> target)
    {
        int damage = caster.GetFinalDamage(attackPower);
        
        foreach (var targetUnit in target)
        {
            targetUnit.TakeDamage(damage);
        }

        caster.ClearDamageBuff();
    }
}
