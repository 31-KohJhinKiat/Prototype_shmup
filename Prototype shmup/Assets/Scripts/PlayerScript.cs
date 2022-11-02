using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Weapons
    GunScript[] guns;

    //Movement speed
    private float moveSpeed = 10;

    //Booleans
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;
    

    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<GunScript>();
        
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

        shoot = Input.GetKey(KeyCode.J);
        if (shoot)
        {
            shoot = false;
            foreach(GunScript gun in guns)
            {
                gun.Shoot();
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

}
