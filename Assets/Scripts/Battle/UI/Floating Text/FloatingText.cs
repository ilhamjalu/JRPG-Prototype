using Fungus.DentedPixel;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CanvasGroup canvasGroup;

    public void Show(string value, Color color)
    {
        text.text = value;
        text.color = color;

        canvasGroup.alpha = 1f;

        Vector3 startPos = transform.localPosition;

        LeanTween.moveLocalY(gameObject, startPos.y + 50f, 1f).setEaseOutQuad();

        LeanTween.alphaCanvas(canvasGroup, 0f, 1f).setEaseOutQuad().setOnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}