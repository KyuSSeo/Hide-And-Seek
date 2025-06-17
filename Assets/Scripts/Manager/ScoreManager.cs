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
        Debug.Log($"점수: {score} 점");
        scoreUI.UpdateScore(score, fail);
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        Debug.Log($"실패 : {fail} 번");
        scoreUI.UpdateScore(score, fail);
        CheckEndCondition();
    }
    public void TimeOver()
    {
        if (GameManager.Instance.State == GameState.End)
            return;
        GameManager.Instance.ChangeGameState(GameState.End);
        Debug.Log("시간 초과로 패배!");
        resultUI.ShowResult(false);
    }

    private void CheckEndCondition()
    {
        if (GameManager.Instance.State == GameState.End)
            return;

        if (score >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("승리!");
            resultUI.ShowResult(true);  
        }
        else if (fail >= 3)
        {
            GameManager.Instance.ChangeGameState(GameState.End);
            Debug.Log("패배!");
            resultUI.ShowResult(false);
        }
    }
}
