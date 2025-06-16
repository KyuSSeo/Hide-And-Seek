using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float remainingTime;
    private bool isRunning = false;

    public void StartTimer(float duration)
    {
        remainingTime = duration;
        isRunning = true;
        gameObject.SetActive(true);
    }

    public void StopTimer()
    {
        isRunning = false;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            isRunning = false;
            gameObject.SetActive(false);
        }

        timerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }
}
