    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class Result : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button titleButton;


        private void RestartGame()
        {
            GameManager.Instance.BtnClick(ButtonType.Restart);
        }

        private void ReturnToTitle()
        {
            GameManager.Instance.BtnClick(ButtonType.Title);
        }

        public void ShowResult(bool result)
        {
            resultText.text = result ? "Win" : "Lose";
            resultText.gameObject.SetActive(true);
            titleButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true); 

            // ¿Ã∫•∆Æ
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(RestartGame);
            titleButton.onClick.RemoveAllListeners();
            titleButton.onClick.AddListener(ReturnToTitle);
        }

        public void HideResult()
        {
            titleButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            resultText.gameObject.SetActive(false);
        }
    }
