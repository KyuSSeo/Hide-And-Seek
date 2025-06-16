using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    public void ShowResult(bool result)
    {
        resultText.text = result ? "Win" : "Lose";
        resultText.gameObject.SetActive(true);
    }

    public void HideResult()
    {
        resultText.gameObject.SetActive(false);
    }
}
