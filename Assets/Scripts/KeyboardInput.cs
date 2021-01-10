using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KeyboardInput : MonoBehaviour
{
    private GameObject txt;
    private GameObject cnvs;
    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("NameText");
        cnvs = GameObject.Find("KeyboardCanvas");
        this.HideKB();
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void GetText() {
        
        txt.GetComponent<TextMeshPro>().text += this.name;
        //txt.GetComponent().text = this.name;

    }

    public void DelText()
    {
        txt.GetComponent<TextMeshPro>().text = "";
        //txt.GetComponent().text = this.name;

    }

    public void Submit()
    {
        ScoreCounter scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        Scores.Instance.PostScore(txt.GetComponent<TextMeshPro>().text, scoreCounter.GetScoreValue());
        SceneManager.LoadScene("ScoreMenu");
    }

    public void ShowKB() {
        cnvs.SetActive(true);
    }

    public void HideKB() {
        cnvs.SetActive(false);
    }
}
