using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagement : MonoBehaviour
{

    public GameObject Story;
    public GameObject MainMenu;

    private void Awake()
    {
        PlayerPrefs.SetInt("Count", 3);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenStory()
    {
        Story.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void OpenMenu()
    {
        MainMenu.SetActive(true);
        Story.SetActive(false);
     
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
