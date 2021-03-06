﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    protected Vector3 move;

    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";

    private Rigidbody playerRigidbody;

    public float moveSpeedIn = 0.5f;
    private float moveSpeed = 1.0f;
    public float x = 0.02f;

    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();

        moveSpeed = moveSpeedIn;
    }

    void FixedUpdate()
    {
        move = GetInputVector(Input.GetAxis(horizontal), Input.GetAxis(vertical));
        move *= Mathf.Lerp(moveSpeedIn, moveSpeed, x) * Time.deltaTime;

        this.transform.position = Move();
        transform.LookAt((this.transform.position + move));  
    }

    public Vector3 GetInputVector(float horizontalMove, float verticalMove)
    {
        return new Vector3(horizontalMove, 0.0f, -verticalMove);
    }

    public Vector3 Move ()
    {
        return new Vector3(this.transform.position.x + move.x, this.transform.position.y, this.transform.position.z + move.z);
    }
}
