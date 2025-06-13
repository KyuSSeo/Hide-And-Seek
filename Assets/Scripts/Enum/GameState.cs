using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState 
{
    GameStart,  // 게임 기동 스테이 선택 단계 
    Preview,    // 게임 시작 전 진짜 오브젝트 확인 시간
    Playing,    // 게임 시작 후 가짜 오브젝트 찾는 시간
    End         // 게임 종료 상태
}