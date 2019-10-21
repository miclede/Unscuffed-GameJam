using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject escMenu;

    public GameObject VictoryMenu;

    public GameObject DefeatMenu;

    public bool defeat;

    public bool victory;

    bool isPaused;

    private void Start()
    {
        escMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !defeat && !victory)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                openMenu();
            }

            else
            {
                closeMenu();
            }
        }

        if (victory)
        {
            AudioListener.pause = false;
            VictoryMenu.SetActive(true);
        }

        if (defeat)
        {
            AudioListener.pause = false;
            DefeatMenu.SetActive(true);
        }

    }

    void openMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        escMenu.SetActive(true);
    }

    void closeMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        escMenu.SetActive(false);
    }
}
