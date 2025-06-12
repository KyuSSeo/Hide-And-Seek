using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum GameState { Preview, Playing, End }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state = GameState.Preview;

    private int score = 0;
    private int fail = 0;

    private void Awake() => Init();

    private void Init()
    {
        Instance = this;
    }
    public void AddScore()
    {
        score++;
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        CheckEndCondition();
    }

    private void CheckEndCondition()
    {
        if (score >= 3)
        {
            state = GameState.End;
            Debug.Log("½Â¸®!");
        }
        else if (fail >= 3)
        {
            state = GameState.End;
            Debug.Log("ÆÐ¹è!");
        }
    }
}