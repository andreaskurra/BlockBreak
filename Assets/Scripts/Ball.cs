﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouceClick();
        }

        //Debug.Log(Input.mousePosition.x);
    }

    private void LaunchOnMouceClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
            //Debug.Log("xPush is : " + xPush);
            //Debug.Log("yPush is : " + yPush);
        }
        myRigidbody2D.velocity = new Vector2(xPush, yPush);
    }

    private void LockBallToPaddle()
    { 
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(randomFactor, Math.Abs(randomFactor))
            ,UnityEngine.Random.Range(randomFactor, Math.Abs(randomFactor)));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
            

        }
        
    }

}



