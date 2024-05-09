using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiMa : MonoBehaviour
{
    [SerializeField] private Image MiMaImage;

    [SerializeField] private LoadScene _sceneLoader;

    private PlaySound _playSound;

    private void Awake()
    {
        _playSound = FindFirstObjectByType<PlaySound>();
    }

    private void Start()
    {
        _playSound.PlayIntro();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitUntil(() => MiMaImage.enabled == false);
        _sceneLoader.ClickToLoad();
    }
}
