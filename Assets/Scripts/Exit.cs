using UnityEngine;

public class Exit : MonoBehaviour
{
    public void OnQuitButton()
    {
        Debug.Log("게임 종료 버튼 클릭됨");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
