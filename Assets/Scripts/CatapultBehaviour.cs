﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapultBehaviour : MonoBehaviour
{
    public enum State { aiming, shooting, idle };
    public State currentState = State.aiming;

    public float power;
    public GameObject ball;
    public Vector3 restingPos;
    public Vector3 offset;

    public Vector2 shot;

    public Vector3 hitPos = new Vector3(0, -2, 0);

    public GameObject ballPrefab;

    private int ballsRemaining = 0;
    private Vector3 ballStartPos;

    public int BallsRemaining
    {
        get { return ballsRemaining; }
        set
        {
            ballsRemaining = value;

            if (ballsRemaining < 0)
            {
                GameManager.Instance.Lose();
            }
        }
    }

    private void Start()
    {
        GameManager.Instance.FindRemainingKnights();
        ballsRemaining = GameManager.Instance.numberOfBalls;
        ballStartPos = ball.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(ballPrefab, hitPos - offset, Quaternion.identity);
            ball = go;
            BallsRemaining--;
            currentState = State.idle;
        }
        switch (currentState)
        {
            case State.aiming:
                Aiming();
                break;
            case State.shooting:
                Shoot();
                break;
            case State.idle:
                Idle();
                break;
            default:
                Debug.Log("Switch sent to Default");
                break;
        }
    }

    void HandleClub(Vector2 position, TouchPhase phase)
    {
        restingPos = Camera.main.ScreenToWorldPoint(position);
        restingPos.z = 0;
        transform.position = restingPos;
        ball.transform.position = transform.position - offset;

        if (phase == TouchPhase.Ended)
        {
            ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            shot = ballStartPos - transform.position;
            shot.Normalize();

            shot *= Vector2.Distance(ballStartPos, transform.position) * power;

            currentState = State.shooting;
        }
    }

    #region Player Controlling Methods
    void Aiming()
    {
        if (Input.GetButton("Fire1"))
        {
            HandleClub(Input.mousePosition, TouchPhase.Moved);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            HandleClub(Input.mousePosition, TouchPhase.Ended);
        }

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            HandleClub(t.position, t.phase);
        }
    }

    void Shoot()
    {
        transform.position = Vector3.MoveTowards(transform.position, hitPos, 10);

        if (transform.position == hitPos)
        {
            ball.GetComponent<Rigidbody2D>().AddForce(shot);
            shot = Vector2.zero;
        }
    }

    void Idle()
    {
        if (ball.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            currentState = State.aiming;
        }
    }

    #endregion

}