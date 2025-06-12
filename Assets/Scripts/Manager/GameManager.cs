using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public void AddScore()
    {
        Debug.Log("점수 증가");
    }

    public void FailAttempt()
    {
        Debug.Log("기회 차감");
    }
}
