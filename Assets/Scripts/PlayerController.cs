﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    protected Vector3 move;

    public string horizontal = "Horizontal_P1";
    public string vertical = "Vertical_P1";

    private Rigidbody playerRigidbody;

    public float moveSpeedIn = 0.5f;
    public float moveSpeed = 1.0f;
    public float x = 0.02f;

    void Awake()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        move = GetInputVector(Input.GetAxis(horizontal), Input.GetAxis(vertical));
        move = move.normalized * Mathf.Lerp(moveSpeedIn, moveSpeed, x) * Time.deltaTime;

        if ((move.x > 0.1 || move.z > 0.1) || (move.x < 0.1 || move.z < 0.1))
        {
            playerRigidbody.MovePosition(this.transform.position + move);
            transform.LookAt(transform.position + move);
        }
    }

    public Vector3 GetInputVector(float horizontalMove, float verticalMove)
    {
        return new Vector3(horizontalMove, 90, -verticalMove);
    }
}