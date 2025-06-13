using System;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //  ����
    public GameState State { get; private set; } = GameState.GameStart;
    //  ����
    public ScoreManager Score { get; set; }


    //  ����Ƽ �̺�Ʈ
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
                Debug.Log("���� ����");
                break;

            case GameState.Preview:
                Debug.Log("���� Ž�� ����");
                break;

            case GameState.Playing:
                Debug.Log("Ž�� ����");
                break;

            case GameState.End:
                Debug.Log("���� ����");
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
}