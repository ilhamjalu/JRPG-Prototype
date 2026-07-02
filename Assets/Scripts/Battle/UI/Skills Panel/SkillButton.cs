using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private SkillData skill;
    private SkillInfoPanel infoPanel;

    public void Init(SkillData skill, SkillInfoPanel panel)
    {
        this.skill = skill;
        infoPanel = panel;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayUIHover();
        infoPanel.Show(skill);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPanel.Hide();
    }
}
