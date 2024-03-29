﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Health
    public int playerHealth = 100;

    //Weapons
    GunScript[] guns;
    BombLauncherScript[] bomb;

    //Audio
    public AudioSource audioSource;
    public AudioClip gunAudio;
    public AudioClip bombLauncherAudio;

    //Movement speed
    private float moveSpeed = 10;

    //Directions
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    //Rapid fire
    bool shoot;
    private float waitTime = 0.1f;
    private float currentShootTime = 0.0f;


    //Nuke
    bool shoot2;
    private float waitTime2 = 3.0f;
    private float currentShootTime2 = 0.0f;

    //Shield
    GameObject shield;


    // Start is called before the first frame update
    void Start()
    {
        //Shield
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();

        //get weapons
        guns = transform.GetComponentsInChildren<GunScript>();
        foreach(GunScript gun in guns)
        {
            gun.isActive = true;
        }

        bomb = transform.GetComponentsInChildren<BombLauncherScript>();
        
        //get audio
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    private void Update()
    {
        //Button input
        moveUp = Input.GetKey(KeyCode.UpArrow) 
            || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow)
            || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D);

        //Time before shoot bullets
        currentShootTime = currentShootTime + Time.deltaTime;

        //Time before launch nuke
        currentShootTime2 = currentShootTime2 + Time.deltaTime;

        shoot = Input.GetKey(KeyCode.J);
            if (shoot == true)
            {
                if (currentShootTime >= waitTime)
                {
                    shootGun();
                    audioSource.PlayOneShot(gunAudio);
                    currentShootTime = 0;

                }

            }

        shoot2 = Input.GetKey(KeyCode.K);
            if (shoot2 == true)
            {
                if (currentShootTime2 >= waitTime2)
                {
                    shootBomb();
                    audioSource.PlayOneShot(bombLauncherAudio);
                    currentShootTime2 = 0;

                }

            }


    }

    private void FixedUpdate()
    {
        //Movement
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = 
            Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        moveMagnitude =
            Mathf.Sqrt(move.x * move.x + move.y * move.y);

        //Debug.Log(moveMagnitude);

        pos += move;

        //boundaries
        if (pos.x <= -5.6f)
        {
            pos.x = -5.6f;
        }
        if (pos.x >= 5.6f)
        {
            pos.x = 5.6f;
        }
        if (pos.y <= -3.8f)
        {
            pos.y = -3.8f;
        }
        if (pos.y >= 3.8f)
        {
            pos.y = 3.8f;
        }

        transform.position = pos;
    }

    public void shootGun()
    {
        print("Activate weapon");
        
        foreach (GunScript gun in guns)
        {
            gun.Shoot();

        }
    }

    public void shootBomb()
    {
        print("Fire bomb!");

        foreach (BombLauncherScript bomb in bomb)
        {
            bomb.Shoot();
        }
    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
    }

    bool HasShield()
    {
        return shield.activeSelf;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BulletScript bullet = 
            collision.GetComponent<BulletScript>();

        if (bullet != null)
        {
            if (bullet.isEnemyBullet)
            {
                playerHealth -= 10;
                Destroy(bullet.gameObject);

                if (playerHealth <= 0)
                {
                    Destroy(gameObject);
                }

            }
        }

        EnemyScript enemyScript = 
            collision.GetComponent<EnemyScript>();

        if (enemyScript != null)
        {
            if (HasShield())
            {
                DeactivateShield();
            }
            else
            {
                playerHealth -= 20;             

                if (playerHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
            Destroy(enemyScript.gameObject);

        }

    }

}
