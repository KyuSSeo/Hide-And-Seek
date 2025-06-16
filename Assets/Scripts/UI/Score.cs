using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScore(int score, int fail)
    {
        scoreText.text = $"score: {score} \n"+$"fail: {fail}";
    }
}
