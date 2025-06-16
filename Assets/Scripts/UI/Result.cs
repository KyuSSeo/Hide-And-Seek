using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;

    public void ShowResult(bool result)
    {
        resultText.text = result ? "½Â¸®" : "ÆÐ¹è";
        resultText.gameObject.SetActive(true);
    }

    public void HideResult()
    {
        resultText.gameObject.SetActive(false);
    }
}
