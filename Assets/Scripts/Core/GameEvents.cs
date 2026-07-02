using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action OnEnemyTurn;
    public static Action OnPlayerTurn;
    public static Action<SkillData> OnSkillSelected;
}
