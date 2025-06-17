using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.Instance.OnBtnClick += HandleButtonClick;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnBtnClick -= HandleButtonClick;
    }

    private void HandleButtonClick(ButtonType button)
    {
        switch (button)
        {
            case ButtonType.Restart:
                RestartGame();
                break;
            case ButtonType.Title:
                GoToTitle();
                break;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToTitle()
    {
        SceneManager.LoadScene("IntroScene");
    }
}
