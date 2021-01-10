using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Transform head;
    [SerializeField] GameObject time;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0 ){
            health = 0;
            time.GetComponent<TimerCounter>().SetTime(0);
            time.GetComponent<TimerCounter>().AddTime();
        }
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }
}
