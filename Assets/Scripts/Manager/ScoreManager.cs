using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Score scoreUI;
    [SerializeField] private Result resultUI;

    private int score = 0;
    private int fail = 0;


    private void Awake()
    {
        GameManager.Instance.Score = this;
    }
    private void Start()
    {
        GameManager.Instance.ChangeGameState(GameState.Preview);
        resultUI.HideResult();
        scoreUI.UpdateScore(score, fail);
    }


    public void AddScore()
    {
        score++;
        scoreUI.UpdateScore(score, fail);
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        scoreUI.UpdateScore(score, fail);
        CheckEndCondition();
    }
    public void TimeOver()
    {
        if (GameManager.Instance.State == GameState.End)
            return;

        GameManager.Instance.ChangeGameState(GameState.End);
        resultUI.ShowResult(false);
    }

    private void CheckEndCondition()
    {
        if (GameManager.Instance.State == GameState.End)
            return;

        if (score >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            resultUI.ShowResult(true);  
        }
        else if (fail >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            resultUI.ShowResult(false);
        }
    }
}
