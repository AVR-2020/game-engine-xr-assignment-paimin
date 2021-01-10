using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] Transform head;

    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage");
        health -= damage;
        if(health < 0 ){
            health = 0;
        }
        Debug.Log(string.Format("Player health: {0}", health));
    }

    public Vector3 GetHeadPosition()
    {
        return head.position;
    }
}
