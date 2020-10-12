using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject Levels;
    
    public void ToMain()
    {
        Main.SetActive(true);
        Levels.SetActive(false);
    }
    public void ToLevels()
    {
        Main.SetActive(false);
        Levels.SetActive(true);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quit");
        Application.Quit();
    }
    public void PlayScene(string name)
    {
        PlayerPrefs.SetString("Level", name);
        SceneManager.LoadScene(2);
    }
    public void BuildScene(string name)
    {
        PlayerPrefs.SetString("Level", name);
        SceneManager.LoadScene(1);
    }
}
