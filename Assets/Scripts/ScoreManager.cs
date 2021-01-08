using NUnit.Framework;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
        Task<Scores.ScoreList> results = scores_instance.GetScore();
        var text = "";
        Scores.ScoreList result = await results;
        foreach (Scores.Score score in result.scores)
        {
            text += score.name;
            text += score.value_score;
            text += "\n";
            Debug.Log(score.value_score);
        }
        ScoreBoardText.GetComponent<UnityEngine.UI.Text>().text = text;
    }
}