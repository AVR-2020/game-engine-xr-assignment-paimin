using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject ScoreBoardText;
    Scores scores_instance = Scores.Instance;
    // Start is called before the first frame update
    public void QuitTogame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public async void RefreshScore()
    {
        // nanti kasih await
        var result = scores_instance.GetScore();
        var text = "";
        foreach (Scores.Score score in result.scores)
        {
            text += score.name;
            text += score.value_score;
            text += "\n";
        }
        
        ScoreBoardText.GetComponent<UnityEngine.UI.Text>().text = text;
    }
}