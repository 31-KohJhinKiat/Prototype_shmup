using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //Can kill enemy
    bool canBeDestroyed = false;

    //Health
    public float enemyHealth;

    //Score
    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        LevelController.instance.AddEnemy();
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
                    LevelController.instance.AddScore(scoreValue);
                    Destroy(gameObject);
                }

            }
        }

    }

    private void OnDestroy()
    {
        LevelController.instance.RemoveEnemy();
    }

}
