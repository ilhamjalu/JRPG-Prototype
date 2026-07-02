using System;
using System.Collections.Generic;

[Serializable]
public class BattleAction
{
    public int IndexActor;

    public BattleUnit Actor;

    public List<BattleUnit> Targets;

    public SkillData Skill;

    public int Priority => Skill.Priority;
}