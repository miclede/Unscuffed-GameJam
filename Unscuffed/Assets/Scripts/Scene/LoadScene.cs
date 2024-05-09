using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private bool _requireFader = true;

    public Image blackImageCheck;
    public Animator fader;

    public int sceneToLoad;

    private PlaySound _playSound;

    private void Awake()
    {
        _playSound = FindFirstObjectByType<PlaySound>();
    }

    public void ClickToLoad()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

        if (!_requireFader)
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        else StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
        fader.SetBool(VarUI.Fade, true);
        yield return new WaitUntil(() => blackImageCheck.color.a == 1);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

}