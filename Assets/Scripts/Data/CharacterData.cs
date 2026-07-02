using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JRPG/Character Data")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public int maxHP;

    public List<SkillData> Skills;
}