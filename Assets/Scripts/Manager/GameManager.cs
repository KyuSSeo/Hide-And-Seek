using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public void AddScore()
    {
        Debug.Log("���� ����");
    }

    public void FailAttempt()
    {
        Debug.Log("��ȸ ����");
    }
}
