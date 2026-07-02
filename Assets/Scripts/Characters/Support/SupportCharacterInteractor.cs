using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportCharacterInteractor : NPCInteraction
{
    [SerializeField] private SupportCharacterController supportCharacterController;

    protected override string GetBlockName()
    {
        return dialogueProgress.HasTalkToPink? "Join": "Reject";
    }

    public void JoinParty()
    {
        supportCharacterController.canMove = true;
        dialogueProgress.SetCompanionJoined();
    }

    public void RejectParty()
    {
        supportCharacterController.canMove = false;
    }
}
