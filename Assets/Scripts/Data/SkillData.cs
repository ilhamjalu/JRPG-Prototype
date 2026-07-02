using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    Self,
    Ally,
    Enemy
}

public enum EffectAnchorType
{
    Cast,
    Heal
}

public abstract class SkillData : ScriptableObject
{
    [Header("Info")]
    public string SkillName;
    public string Description;
    public string CastLine;

    [Header("Priority")]
    public int Priority;

    public TargetType TargetType;

    [Header("Animation")]
    public GameObject animation;
    public EffectAnchorType EffectAnchorType;

    [Header("Audio")]
    public AudioClip Sfx;

    public abstract void Execute(BattleUnit caster, List<BattleUnit> target);
}