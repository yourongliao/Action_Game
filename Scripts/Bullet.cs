﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 10;

    public float attack = 100;

    void Start()
    {
        Destroy(this.gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == Tags.soulBoss || col.tag == Tags.soulMonster)
        {
            col.GetComponent<ATKAndDamage>().TakeDamage(attack);
        }
    }
}
