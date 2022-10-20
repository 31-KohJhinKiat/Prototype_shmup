using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    public float BulletSpeed;
    private float timeDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        timeDestroyed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * BulletSpeed * Time.deltaTime;

        timeDestroyed += Time.deltaTime;
        if (timeDestroyed >= 3)
        {
            Destroy(gameObject);
            print("Bullet disappeared");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
