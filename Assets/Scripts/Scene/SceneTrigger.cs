using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private DialogueProgress dialogueProgress;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || !dialogueProgress.CompanionJoined)
            return;

        SceneChanger.Instance.LoadScene(sceneName);
    }
}
