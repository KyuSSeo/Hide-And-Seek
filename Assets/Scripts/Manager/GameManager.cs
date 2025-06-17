using System;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    //  상태
    public GameState State { get; private set; } = GameState.GameStart;
    //  점수
    public ScoreManager Score { get; set; }


    //  유니티 이벤트
    public event Action<GameState> OnGameStateChanged;
    public event Action<ButtonType> OnBtnClick;

    private void Awake()
    {
        SingletonInit();
    }

    public void BtnClick(ButtonType button)
    {
        OnBtnClick?.Invoke(button);
    }
    public void ChangeGameState(GameState newState)
    {
        if (State == newState) 
            return;

        State = newState;
        OnGameStateChanged?.Invoke(newState);
    }
}