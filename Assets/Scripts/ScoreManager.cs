using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    Scores scores_instance = Scores.Instance;
    // Start is called before the first frame update
    public void QuitTogame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RefreshScore()
    {
        scores_instance.GetScore();
    }
}