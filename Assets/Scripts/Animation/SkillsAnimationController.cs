using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsAnimationController : MonoBehaviour
{
    [SerializeField] private Transform healAnchor;
    [SerializeField] private Transform castAnchor;

    public void SpawnAnimation(GameObject skill, EffectAnchorType type)
    {
        Instantiate(skill, GetAchor(type));
    }

    public IEnumerator PlaySkillEffect(GameObject skill, EffectAnchorType type)
    {
        if (skill == null)
            yield break;

        SkillEffect effect = Instantiate(skill, GetAchor(type)).GetComponent<SkillEffect>();

        yield return new WaitUntil(() => effect.IsFinished);
    }

    Transform GetAchor(EffectAnchorType type)
    {
        switch (type)
        {
            case EffectAnchorType.Cast:
                return castAnchor;

            case EffectAnchorType.Heal:
                return healAnchor;
            default:
                return transform;
        }
    }
}
