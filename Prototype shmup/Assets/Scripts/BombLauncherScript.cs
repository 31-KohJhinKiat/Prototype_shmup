using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncherScript : MonoBehaviour
{
    public BombScript bomb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation *
            Vector2.up).normalized;
    }

    public void Shoot()
    {
        GameObject go =
            Instantiate(bomb.gameObject,
            transform.position, transform.rotation);

        BombScript goBomb =
            go.GetComponent<BombScript>();

        goBomb.direction = direction;
    }

}
