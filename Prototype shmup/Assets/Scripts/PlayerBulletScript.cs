using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    //Bullet direction and speed
    public Vector2 direction = new Vector2(1, 0);
    private float speed = 80;

    public Vector2 velocity;

    //Bullet disappear
    private float timeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        timeDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;

        //Time before bullet disappearance
        timeDestroyed += Time.deltaTime;
        if (timeDestroyed >= 3)
        {
            Destroy(gameObject);
            print("Bullet disappeared");
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.fixedDeltaTime;
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
