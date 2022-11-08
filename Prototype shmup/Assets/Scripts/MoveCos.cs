using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCos : MonoBehaviour
{
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

        float cos = Mathf.Cos(pos.y);
        pos.y = cos;

        transform.position = pos;
    }

}
