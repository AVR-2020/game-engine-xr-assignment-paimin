﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int ScoreValue;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject timerText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
    }

    // Update is called once per frame
    public void AddScore(int point)
    {
        ScoreValue += point;
        //Debug.Log(scoreText);
        scoreText.GetComponent<Text>().text = ScoreValue.ToString();
        timerText.GetComponent<TimerCounter>().bonusTime();
    }
    public int GetScoreValue ()
    {
        return ScoreValue;
    }
}
