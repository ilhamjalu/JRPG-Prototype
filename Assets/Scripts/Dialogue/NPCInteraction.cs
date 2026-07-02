using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Flowchart flowchart;
    [SerializeField] public DialogueProgress dialogueProgress;

    public void Interact()
    {
        if (dialogueProgress.CompanionJoined) return;

        string block = GetBlockName();

        flowchart.ExecuteBlock(block);
    }

    protected virtual string GetBlockName()
    {
        return "Dialogue_1";
    }
}
