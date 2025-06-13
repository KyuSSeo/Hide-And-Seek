using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int fail = 0;


    private void Awake()
    {
        GameManager.Instance.Score = this;
    }
    private void Start()
    {
        GameManager.Instance.ChangeGameState(GameState.Preview);
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
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("�¸�!");
        }
        else if (fail >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("�й�!");
        }
    }
}
