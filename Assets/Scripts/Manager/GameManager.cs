using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : Singleton<GameManager>
{

    //  상태
    public GameState State { get; private set; } = GameState.GameStart;
    
    //  점수
    private int score = 0;
    private int fail = 0;

    private void Start()
    {
        ChangeState(GameState.Preview);
    }


    public void AddScore()
    {
        score++;
        Debug.Log($"점수: {score} 점");
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        Debug.Log($"실패 : {fail} 번");
        CheckEndCondition();
    }

    private void CheckEndCondition()
    {
        if (score >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("승리!");
        }
        else if (fail >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("패배!");
        }
    }
    public void ChangeState(GameState state)
    {

    }
}