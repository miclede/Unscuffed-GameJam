using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MiMa : MonoBehaviour
{
    public Image MiMaImage;
    public Image blackBackground;

    public Image fadeImageCheck;
    public Animator fader;

    AudioSource StartPageAudio;

    private void Start()
    {
        StartPageAudio = GetComponent<AudioSource>();
        StartCoroutine(Fade());
    }

    void StartMusic()
    {
        StartPageAudio.Play();
    }

    IEnumerator Fade()
    {
        fader.SetBool(VarUI.Fade, true);
        yield return new WaitUntil(() => MiMaImage.enabled == false);
        StartMusic();
        blackBackground.enabled = false;
        yield return new WaitUntil(() => blackBackground.enabled == false);
        fader.SetBool(VarUI.Fade, false);
        yield return new WaitUntil(() => fadeImageCheck.enabled == false);
    }
}
