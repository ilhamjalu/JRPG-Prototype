using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueProgress : MonoBehaviour
{
    public bool HasTalkToPink {  get; private set; }
    public bool CompanionJoined {  get; private set; }

    public void SetHasTalkToPink()
    {
        HasTalkToPink = true;
    }

    public void SetCompanionJoined()
    {
        CompanionJoined = true;
    }
}
