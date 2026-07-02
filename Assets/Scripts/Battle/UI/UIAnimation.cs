using Fungus.DentedPixel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] private List<RectTransform> playerPartyPanels;
    [SerializeField] private float duration = 0.15f;
    [SerializeField] private float popInScale = 1.1f;
    [SerializeField] private float popOutScale = 0.9f;
    private readonly Color selectedColor = Color.white;
    private readonly Color unselectedColor = new Color32(162, 162, 162, 255);

    private void Start()
    {
        HighlightCharacter(0);
    }

    public void PopIn(int index)
    {
        LeanTween.cancel(playerPartyPanels[index]);

        playerPartyPanels[index].localScale = Vector3.one;

        LeanTween.scale(playerPartyPanels[index], Vector3.one * popInScale, duration).setEaseOutBack();

        HighlightCharacter(index);
    }

    public void PopOut(int index)
    {
        LeanTween.cancel(playerPartyPanels[index]);

        LeanTween.scale(playerPartyPanels[index], Vector3.one, duration).setEaseInBack();
    }

    public void HighlightCharacter(int index)
    {
        for (int i = 0; i < playerPartyPanels.Count; i++)
        {
            SetPanelColor(playerPartyPanels[i], i == index ? selectedColor : unselectedColor);
        }
    }

    public void UnhiglightCharacters()
    {
        foreach (RectTransform panel in playerPartyPanels)
        {
            SetPanelColor(panel, unselectedColor);
        }
    }

    private void SetPanelColor(RectTransform panel, Color color)
    {
        foreach (Image image in panel.GetComponentsInChildren<Image>())
        {
            image.color = color;
        }
    }
}
