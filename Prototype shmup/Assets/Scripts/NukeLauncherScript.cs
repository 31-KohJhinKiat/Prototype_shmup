using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeLauncherScript : MonoBehaviour
{
    public PlayerNukeScript nuke;
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
            Instantiate(nuke.gameObject,
            transform.position, transform.rotation);

        PlayerNukeScript goNuke =
            go.GetComponent<PlayerNukeScript>();

        goNuke.direction = direction;
    }

}
