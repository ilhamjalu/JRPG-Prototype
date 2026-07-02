using Fungus.DentedPixel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private RectTransform panel;

    [SerializeField] private TextMeshProUGUI description;

    [SerializeField] private float duration = 0.2f;
    [SerializeField] private float offset = 50f;

    private Vector2 targetPos;
    private bool isShowing;

    private void Awake()
    {
        targetPos = panel.anchoredPosition;

        canvasGroup.alpha = 0;
    }

    public void Show(SkillData skill)
    {
        description.text = skill.Description;

        if (isShowing) LeanTween.cancel(panel);

        panel.anchoredPosition = targetPos + Vector2.left * offset;
        canvasGroup.alpha = 0;

        LeanTween.move(panel, targetPos, duration).setEaseOutQuad();

        LeanTween.alphaCanvas(canvasGroup, 1, duration);

        isShowing = true;
    }

    public void Hide()
    {
        if (!isShowing)
            return;

        LeanTween.cancel(panel);

        LeanTween.move(panel, targetPos + Vector2.left * offset, duration).setEaseInQuad();

        LeanTween.alphaCanvas(canvasGroup, 0, duration);

        isShowing = false;
    }
}