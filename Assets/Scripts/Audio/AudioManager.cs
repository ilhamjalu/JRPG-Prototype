using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource uiSource;

    [Header("UI")]
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;

    [Header("Victory & Defeat")]
    [SerializeField] private AudioClip defeatClip;
    [SerializeField] private AudioClip victoryClip;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySfx(AudioClip clip)
    {
        uiSource.PlayOneShot(clip);
    }

    public void PlayUIClick()
    {
        uiSource.PlayOneShot(clickClip);
    }

    public void PlayUIHover()
    {
        uiSource.PlayOneShot(hoverClip);
    }

    [ContextMenu("PLAY VICTORY")]
    public void PlayVictory()
    {
        uiSource.PlayOneShot(victoryClip);
    }

    [ContextMenu("PLAY DEFEAT")]
    public void PlayDefeat()
    {
        uiSource.PlayOneShot(defeatClip);
    }
}
