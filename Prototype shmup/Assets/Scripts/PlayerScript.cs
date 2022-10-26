using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Audio
    public AudioSource audioSource;
    public AudioClip BulletSound;

    //Movementspeed
    public float movementSpeed;

    //Shoot Bullets
    public GameObject playerBulletPrefab;
    public GameObject playerBulletSpawn1;

    public bool canShoot = true;
    private float waitTime = 0.1f;
    private float currentShootTime = 0.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement

        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.y <= 3.8f)
            {
                transform.position += 
                    transform.up * movementSpeed * Time.deltaTime;
            }


        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x >= -5.8f)
            {
                transform.position -= 
                    transform.right * movementSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.y >= -3.8f)
            {
                transform.position -= 
                    transform.up * movementSpeed * Time.deltaTime;
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x <= 5.8f)
            {
                transform.position += 
                    transform.right * movementSpeed * Time.deltaTime;
            }

        }

        //Attacks
        currentShootTime = currentShootTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.J))
        {
            if (currentShootTime >= waitTime)
            {
                ShootBullets();
                playShootSound();

                currentShootTime = 0;
            }

            

        }

    }

    public void ShootBullets()
    {
        Instantiate(playerBulletPrefab,
                playerBulletSpawn1.transform.position,
                transform.rotation);

    }

    public void playShootSound()
    {
        audioSource.PlayOneShot(BulletSound);
    }

}
