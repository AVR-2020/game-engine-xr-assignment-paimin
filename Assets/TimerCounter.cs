using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    Text text;
    [SerializeField] private static float TimerValue = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
    [SerializeField] GameObject KeyboardCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.GetTimerValue());
        // text.text = System.Convert.ToString(System.Math.Round(GetTimerValue(), 2));
        text.text = GetTimerValue().ToString("0.00");
        AddTime();
    }
    public void SetTime(float second)
    {
        TimerValue = second;
    }
    public void AddTime()
    {
        TimerValue -= Time.deltaTime;
        if(TimerValue <= 0.0)
        {
<<<<<<< Updated upstream
            //stop game
=======
            TimerValue = 0;
>>>>>>> Stashed changes
        }
    }
    public double GetTimerValue()
    {
        return System.Math.Round(TimerValue, 2);
    }
}
