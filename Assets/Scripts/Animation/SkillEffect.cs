using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public bool IsFinished { get; private set; }

    public void AnimationFinished()
    {
        IsFinished = true;
        Destroy(gameObject);
    }
}
