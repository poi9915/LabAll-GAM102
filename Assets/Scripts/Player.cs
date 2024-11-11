using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;

    public float speedMove;

    public int jump;

    [SerializeField] private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        speedMove = 4;
        jump = 8;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jump);
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            speedMove++;
            timer = 5;
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(speedMove, _rb.linearVelocity.y);
    }
}