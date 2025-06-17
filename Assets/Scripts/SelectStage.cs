using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    [SerializeField] private string _stageName;

    public void OnSelectStage()
    {
        if (!string.IsNullOrEmpty(_stageName))
        {
            SceneManager.LoadScene(_stageName);
        }
    }
}
