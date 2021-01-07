using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitTogame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
