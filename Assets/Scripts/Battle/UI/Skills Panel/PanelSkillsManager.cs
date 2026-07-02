using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelSkillsManager : MonoBehaviour
{
    [SerializeField] GameObject skillButtonPrefab;
    [SerializeField] BattleManager battleManager;
    [SerializeField] GameObject skillPanel;
    [SerializeField] UIAnimation uIAnimation;
    [SerializeField] SkillInfoPanel skillInfoPanel;

    private void OnEnable()
    {
        GameEvents.OnEnemyTurn += ResetSkillsUI;
        GameEvents.OnPlayerTurn += ShowSkillsUI;
    }
    private void OnDisable()
    {
        GameEvents.OnEnemyTurn -= ResetSkillsUI;
        GameEvents.OnPlayerTurn -= ShowSkillsUI;
    }

    [ContextMenu("Test spawn UI Skills")]
    public void UpdateSkillsUI(BattleUnit battleunit)
    {
        foreach (Transform child in skillPanel.transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < battleunit.Data.Skills.Count; i++)
        {
            GameObject skillButton = Instantiate(skillButtonPrefab, skillPanel.transform);
            skillButton.GetComponentInChildren<TextMeshProUGUI>().text = battleunit.Data.Skills[i].SkillName;

            var skill = battleunit.Data.Skills[i];

            SkillButton skillButtonComponent = skillButton.GetComponent<SkillButton>();
            skillButtonComponent.Init(skill, skillInfoPanel);

            skillButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                AudioManager.Instance.PlayUIClick();
                GameEvents.OnSkillSelected?.Invoke(skill);
            });   
        }
    }

    public void ResetSkillsUI()
    {
        skillPanel.transform.parent.gameObject.SetActive(false);
        skillInfoPanel.Hide();

        uIAnimation.UnhiglightCharacters();
        uIAnimation.PopOut(0);
        uIAnimation.PopOut(1);
    }

    void ShowSkillsUI()
    {
        skillPanel.transform.parent.gameObject.SetActive(true);

        uIAnimation.PopIn(0);
    }
}
