using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Weapons
    GunScript[] guns;
    NukeLauncherScript[] nuke;

    //Audio
    public AudioSource audioSource;
    public AudioClip gunAudio;
    public AudioClip nukeLauncherAudio;

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

    // Start is called before the first frame update
    void Start()
    {
        //get weapons
        guns = transform.GetComponentsInChildren<GunScript>();
        nuke = transform.GetComponentsInChildren<NukeLauncherScript>();
        
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

        //Rapid fire
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
                shootNuke();
                audioSource.PlayOneShot(nukeLauncherAudio);
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

    public void shootNuke()
    {
        print("Fire nuke");

        foreach (NukeLauncherScript nuke in nuke)
        {
            nuke.Shoot();

        }
    }

}
