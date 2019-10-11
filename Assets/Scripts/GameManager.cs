using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public List<Level> levelList = new List<Level>();

    public int numberOfBalls = 1;

    public int knightsRemaining;

    public int currency;

    public GameObject cannonBall;

    public GameObject winUI;

    public GameObject loseUI;

    public int KnightsRemaining
    {
        get { return knightsRemaining; }
        set
        {
            knightsRemaining = value;

            if (knightsRemaining <= 0)
            {
                Win();
            }
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FindRemainingKnights()
    {
        knightsRemaining = FindObjectsOfType<Knight>().Length;
    }

    public void Win()
    {
        winUI.SetActive(true);
    }

    public void Lose()
    {
        loseUI.SetActive(true);
    }
}
