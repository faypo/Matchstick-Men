﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float time;
    public int damage;

    public Animator anima;
    public PolygonCollider2D coll2d;

    private void Start()
    {
        anima = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coll2d = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        attack();
    }

    private void attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            anima.SetTrigger("Attack");
            coll2d.enabled = true;
            StartCoroutine(disableHitBox());
        }
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coll2d.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().getHit(damage);  
        }
    }

}