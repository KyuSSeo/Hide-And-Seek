using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : Singleton<GameManager>
{

    //  ����
    public GameState State { get; private set; } = GameState.GameStart;
    
    //  ����
    private int score = 0;
    private int fail = 0;

    private void Start()
    {
        ChangeState(GameState.Preview);
    }


    public void AddScore()
    {
        score++;
        Debug.Log($"����: {score} ��");
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        Debug.Log($"���� : {fail} ��");
        CheckEndCondition();
    }

    private void CheckEndCondition()
    {
        if (score >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("�¸�!");
        }
        else if (fail >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("�й�!");
        }
    }
    public void ChangeState(GameState state)
    {

    }
}