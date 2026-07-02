using Fungus;
using Fungus.DentedPixel;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvatarAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform panel;

    [SerializeField] private float endX = 300f;
    [SerializeField] private float startX = -600f;
    [SerializeField] private float overshoot = 20f;

    [SerializeField] private Image avatarIcon;
    [SerializeField] private List<Sprite> icons;
    [SerializeField] private TextMeshProUGUI skillName;

    public void ShowSkill(string name)
    {
        skillName.text = name;

        PlayAnimation();
    }

    [ContextMenu("TEST PLAY AVATAR ANIMATION")]
    public void PlayAnimation()
    {
        panel.anchoredPosition = new Vector2(startX, panel.anchoredPosition.y);

        LeanTween.move(panel, new Vector2(endX, panel.anchoredPosition.y), 0.5f)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(() =>
            {
                LeanTween.delayedCall(gameObject, 0.3f, () =>
                {
                    LeanTween.move(panel, new Vector2(startX, panel.anchoredPosition.y), 0.3f)
                        .setEaseInQuad();
                });
            });
    }
}
