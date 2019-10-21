using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Image blackImageCheck;
    public Animator fader;

    public int sceneToLoad;

    public void ClickToLoad()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GetComponent<PlaySound>().playButton();
        StartCoroutine(FadeAndLoad());
    }

    IEnumerator FadeAndLoad()
    {
        fader.SetBool(VarUI.Fade, true);
        yield return new WaitUntil(() => blackImageCheck.color.a == 1);
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

}