using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button titleButton;

    public void ShowResult(bool result)
    {
        resultText.text = result ? "Win" : "Lose";
        resultText.gameObject.SetActive(true);
        titleButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void HideResult()
    {
        titleButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        resultText.gameObject.SetActive(false);
    }
}
