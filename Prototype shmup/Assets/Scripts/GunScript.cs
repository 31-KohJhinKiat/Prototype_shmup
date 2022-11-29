using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public BulletScript bullet;
    Vector2 direction;

    //Auto fire
    public bool autoShoot;
    public float shootIntervalSeconds;
    public float shootDelaySeconds;
    float shootTimer = 0f;
    float delayTimer = 0f;

    // Is active
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            return;
        }

        direction = (transform.localRotation *
            Vector2.up).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }

            }
            else
            {
                delayTimer += Time.deltaTime;
            }

        }

    }

    public void Shoot()
    {
        GameObject go =
            Instantiate(bullet.gameObject,
            transform.position, transform.rotation);

        BulletScript goBullet = 
            go.GetComponent<BulletScript>();

        goBullet.direction = direction;
    }

}
