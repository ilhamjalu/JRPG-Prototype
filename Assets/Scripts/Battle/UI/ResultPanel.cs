using Fungus.DentedPixel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private bool isVictory;
    [SerializeField] private CutSceneController cutSceneController;
    [SerializeField] private CanvasGroup continueCanvasGroup;

    private bool canContinue;

    private void OnEnable()
    {
        canContinue = false;

        LeanTween.delayedCall(gameObject, 0.3f, () =>
        {
            canContinue = true;
        });

        continueCanvasGroup.alpha = 1;

        LeanTween.alphaCanvas(continueCanvasGroup, 0.3f, 0.8f).setLoopPingPong();
    }

    private void OnDisable()
    {
        LeanTween.cancel(continueCanvasGroup.gameObject);
    }

    private void Update()
    {
        if (!canContinue)
            return;

        if (Input.GetKeyDown(KeyCode.Space) ||Input.GetMouseButtonDown(0))
        {
            Continue();
        }
    }

    private void Continue()
    {
        if (isVictory)
        {
            cutSceneController.PlayTimeline();
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}