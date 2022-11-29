using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool canBeDestroyed = false;
    public float enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3.7f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            GunScript[] guns = 
                transform.GetComponentsInChildren<GunScript>();
            foreach (GunScript gun in guns)
            {
                gun.isActive = true;
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }

        BulletScript Bullet = 
            collision.GetComponent<BulletScript>();
        if (Bullet != null)
        {
            if (!Bullet.isEnemyBullet)
            {
                enemyHealth--;
                Destroy(Bullet.gameObject);

                if (enemyHealth <= 0)
                {
                    Destroy(gameObject);
                }

            }
        }

    }

}
