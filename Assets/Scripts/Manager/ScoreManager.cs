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
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("승리!");
        }
        else if (fail >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("패배!");
        }
    }
}
