using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

    [Header("Visual")]
    [SerializeField] private Animator animator;
    [SerializeField] public SkillsAnimationController skillAnimationController;

    [SerializeField] public Transform FloatingTextAnchor;

    [SerializeField] private FloatingTextManager floatingTextManager;

    public bool isAnimationFinished;

    public AvatarAnimation avatar;

    public CharacterData Data => characterData;

    public int CurrentHP { get; private set; }

    public int DamageModifier { get; private set; }

    public bool IsDead => CurrentHP <= 0;

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        CurrentHP = characterData.maxHP;
    }

    public void TakeDamage(int damage)
    {
        CurrentHP -= damage;
        floatingTextManager.ShowDamage(this, damage);

        CurrentHP = Mathf.Max(0, CurrentHP);

        if (CurrentHP <= 0)
        {
            PlayDeathAnimation();
        }
        else
        {
            PlayHitAnimation();
        }
    }

    public int GetFinalDamage(int damage)
    {
        return damage + DamageModifier;
    }

    public void Heal(int amount)
    {
        CurrentHP += amount;

        floatingTextManager.ShowHeal(this, amount);

        CurrentHP = Mathf.Min(CurrentHP, characterData.maxHP);
    }

    public void AddDamageBuff(int amount)
    {
        DamageModifier += amount;
        floatingTextManager.ShowBuff(this, amount);
    }

    public void ClearDamageBuff()
    {
        DamageModifier = 0;
    }

    public void PlayAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public void PlayHitAnimation()
    {
        animator.SetTrigger("GotHit");
    }

    public void PlayDeathAnimation()
    {
        isAnimationFinished = false;

        animator.SetTrigger("Death");
    }

    public IEnumerator WaitUntilDeathAnimationFinished()
    {
        if (!IsDead)
            yield break;

        yield return new WaitUntil(() => isAnimationFinished);

        HideSprite();
    }

    public void HideSprite()
    {
        foreach(SpriteRenderer sprite in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.enabled = false;
        }
    }

    public void AnimationFinished()
    {
        isAnimationFinished = true;
    }
}