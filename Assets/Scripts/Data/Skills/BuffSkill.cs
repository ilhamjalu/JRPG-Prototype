using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Battle/Buff Skill")]
public class BufsfSkill : SkillData
{
    public int buffDamage;

    public override void Execute(BattleUnit caster, List<BattleUnit> targets)
    {
        foreach (BattleUnit target in targets)
        {
            target.AddDamageBuff(buffDamage);
        }
    }
}
