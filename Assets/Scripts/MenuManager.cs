using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    public void Quitgame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    public void ShowScore()
    {
        SceneManager.LoadScene("ScoreMenu");
    }
}
