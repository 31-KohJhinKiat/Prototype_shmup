﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public PlayerBulletScript bullet;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation *
            Vector2.up).normalized;
    }

    public void Shoot()
    {
        GameObject go =
            Instantiate(bullet.gameObject,
            transform.position, transform.rotation);

        PlayerBulletScript goBullet = 
            go.GetComponent<PlayerBulletScript>();

        goBullet.direction = direction;
    }

}
