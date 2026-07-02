using Fungus;
using Fungus.DentedPixel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CutSceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Flowchart flowchart;
    [SerializeField] private GameObject theEndPanel;
    [SerializeField] private CanvasGroup theEndCanvasGroup;

    [ContextMenu("TEST TIMELINE")]
    public void PlayTimeline()
    {
        director.Play();
    }

    public void StartDialogue()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
        flowchart.ExecuteBlock("AfterBattle");
    }

    public void ResumeTimeline()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }

    public void ShowTheEnd()
    {
        theEndPanel.SetActive(true);

        theEndPanel.GetComponentInChildren<Button>().onClick.AddListener(() => SceneChanger.Instance.LoadScene("ExplorationScene"));

        theEndCanvasGroup.alpha = 0;

        LeanTween.alphaCanvas(theEndCanvasGroup, 1f, 0.5f);
    }
}
