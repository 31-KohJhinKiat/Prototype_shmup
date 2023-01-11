using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.y -= enemySpeed * Time.fixedDeltaTime;

        if (pos.y < -12)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
