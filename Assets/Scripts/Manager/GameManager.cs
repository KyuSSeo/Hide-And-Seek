using System;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //  상태
    public GameState State { get; private set; } = GameState.GameStart;
    //  점수
    public ScoreManager Score { get; set; }


    //  유니티 이벤트
    public event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        SingletonInit();
    }

    public void ChangeGameState(GameState newState)
    {
        if (State == newState) 
            return;

        State = newState;

        switch (newState)
        {
            case GameState.GameStart:
                Debug.Log("게임 시작");
                break;

            case GameState.Preview:
                Debug.Log("사전 탐색 시작");
                break;

            case GameState.Playing:
                Debug.Log("탐색 시작");
                break;

            case GameState.End:
                Debug.Log("게임 종료");
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
}