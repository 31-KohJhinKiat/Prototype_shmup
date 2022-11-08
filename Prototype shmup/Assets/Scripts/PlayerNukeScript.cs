using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNukeScript : MonoBehaviour
{
    //Bullet direction and speed
    public Vector2 direction = new Vector2(0, 1);
    private float speed = 10f;

    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;



    }

}
