﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    //Variables
    float sinCenterX;
    private float amplitude = 2;
    private float frequency = 0.5f;

    //Inverted
    public bool inverted = false;

    // Start is called before the first frame update
    void Start()
    {
        sinCenterX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.y * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.x = sinCenterX + sin;

        transform.position = pos;
    }
}
