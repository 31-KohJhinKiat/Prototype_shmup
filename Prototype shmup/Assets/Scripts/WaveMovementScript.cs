using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovementScript : MonoBehaviour
{
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= movespeed * Time.fixedDeltaTime;

        if (pos.y < -12)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }

}
