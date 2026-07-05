using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleView : MonoBehaviour
{
    [Header("HP BAR")]
    [SerializeField] private Slider playerHpBar;
    [SerializeField] private Slider supportHP;
    [SerializeField] private Slider enemyHpBar;

    [SerializeField] private TMP_Text battleLog;

    [SerializeField] private AvatarAnimation avatarAnimation;
    [SerializeField] private AvatarAnimation enemyAvatarAnimation;

    [Header("Panel")]
    public GameObject DefeatPanel;
    public GameObject VictoryPanel;

    public void UpdatePlayerHP(int current, int max)
    {
        playerHpBar.maxValue = max;
        playerHpBar.value = current;
    }

    public void UpdateSupportHP(int current, int max)
    {
        supportHP.maxValue = max;
        supportHP.value = current;
    }

    public void UpdateEnemyHP(int current, int max)
    {
        enemyHpBar.maxValue = max;
        enemyHpBar.value = current;
    }

    public void SetBattleLog(string text)
    {
        battleLog.text = text;
    }

    public void ShowPanel(bool isWin)
    {
        if (isWin)
        {
            VictoryPanel.SetActive(true);
            enemyHpBar.gameObject.SetActive(false);
        }
        else DefeatPanel.SetActive(true);
    }
}