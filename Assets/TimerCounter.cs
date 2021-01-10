using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCounter : MonoBehaviour
{
    Text text;
    [SerializeField] float TimerValue = 60.0f;
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
            TimerValue = 0;
            KeyboardCanvas.GetComponent<KeyboardInput>().ShowKB();
            Time.timeScale = 0;
        }
    }
    public double GetTimerValue()
    {
        return System.Math.Round(TimerValue, 2);
    }
}
