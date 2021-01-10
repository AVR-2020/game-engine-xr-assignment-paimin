using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int ScoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void AddScore(int point)
    {
        this.ScoreValue += point;
    }
    public int GetScoreValue ()
    {
        return this.ScoreValue;
    }
}
