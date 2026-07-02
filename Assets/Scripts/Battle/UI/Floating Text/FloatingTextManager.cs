using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FloatingTextManager : MonoBehaviour
{
    [SerializeField] private FloatingText floatingTextPrefab;
    [SerializeField] private Transform floatingTextContainer;

    private FloatingText ShowText(BattleUnit target, int amount)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.FloatingTextAnchor.position);

        FloatingText text = Instantiate(floatingTextPrefab, floatingTextContainer);

        text.transform.position = screenPos;

        return text;
    }

    public void ShowDamage(BattleUnit target, int damage)
    {
        ShowText(target, damage).Show($"-{damage}", Color.red);
    }

    public void ShowHeal(BattleUnit target, int heal)
    {
        ShowText(target, heal).Show($"+{heal}", Color.green);
    }

    public void ShowBuff(BattleUnit target, int buff)
    {
        ShowText(target, buff).Show($"+{buff} Buff", Color.yellow);
    }
}