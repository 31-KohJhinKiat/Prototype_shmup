using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Bullet direction and speed
    public Vector2 direction = new Vector2(0, 1);
    public float speed = 50f;

    public Vector2 velocity;

    //Enemy bullet
    public bool isEnemyBullet;

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
