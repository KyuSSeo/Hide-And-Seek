using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //  Ž��ð�
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
        }
    }

    private IEnumerator StartTimer(float duration, GameState nextState)
    {
        float remaining = duration;

        while (remaining > 0f)
        {
            Debug.Log($"���� �ð�: {remaining}��");
            yield return new WaitForSeconds(1f);
            remaining -= 1f;
        }
        GameManager.Instance.ChangeGameState(nextState);
    }
}
