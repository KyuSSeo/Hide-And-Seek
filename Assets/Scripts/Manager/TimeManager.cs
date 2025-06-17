using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //  티이머 UI
    [SerializeField] private Timer timer;
    //  탐사시간
    [SerializeField] private float previewDuration = 10f;
    [SerializeField] private float playingDuration = 60f;

    private Coroutine timerRoutine;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }   
    private void OnGameStateChanged(GameState newState)
    {
        if (timerRoutine != null)
            StopCoroutine(timerRoutine);

        switch (newState)
        {
            case GameState.Preview:
                timerRoutine = StartCoroutine(StartTimer(previewDuration, GameState.Playing));
                break;
            case GameState.Playing:
                timerRoutine = StartCoroutine(StartTimer(playingDuration, GameState.End));
                break;
            default:
                if (timer != null) timer.StopTimer();
                break;
        }
    }

    private IEnumerator StartTimer(float duration, GameState nextState)
    {
        float remaining = duration;

        if (timer != null)
            timer.StartTimer(duration);

        yield return new WaitForSeconds(duration);

        if (timer != null)
            timer.StopTimer();

        GameManager.Instance.ChangeGameState(nextState);


        while (remaining > 0f)
        {
            Debug.Log($"남은 시간: {remaining}초");
            yield return new WaitForSeconds(1f);
            remaining -= 1f;
        }

        //  시간 초과
        if (timer != null)
            timer.StopTimer();

        if (nextState == GameState.End)
        {
            GameManager.Instance.Score.TimeOver();
        }
        else
        {
            GameManager.Instance.ChangeGameState(nextState);
        }
    }
}
