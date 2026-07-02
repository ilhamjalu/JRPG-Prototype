using Fungus.DentedPixel;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeDuration = 0.5f;

    private bool isLoading;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        fadeCanvas.alpha = 1f;
        StartCoroutine(FadeIn());
    }

    public void LoadScene(string sceneName)
    {
        if (isLoading)
            return;

        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    public void ReloadCurrentScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        isLoading = true;

        yield return FadeOut();

        yield return SceneManager.LoadSceneAsync(sceneName);

        yield return FadeIn();

        isLoading = false;
    }

    private IEnumerator FadeOut()
    {
        bool finished = false;

        LeanTween.alphaCanvas(fadeCanvas, 1f, fadeDuration)
            .setEaseInOutQuad()
            .setOnComplete(() => finished = true);

        yield return new WaitUntil(() => finished);
    }

    private IEnumerator FadeIn()
    {
        bool finished = false;

        LeanTween.alphaCanvas(fadeCanvas, 0f, fadeDuration)
            .setEaseInOutQuad()
            .setOnComplete(() => finished = true);

        yield return new WaitUntil(() => finished);
    }
}