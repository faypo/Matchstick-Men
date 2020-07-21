using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int demage;


    public void Update()
    {
        isdead();
    }

    public void isdead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void getHit(int demage)
    {
        health -= demage;
    }
}
