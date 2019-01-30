﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xpush = 2f;
    [SerializeField] float ypush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component References
    AudioSource myAudioSource;

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}

	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
	}

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
        }
        
    }
}