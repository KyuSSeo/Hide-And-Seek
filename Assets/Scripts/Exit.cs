using UnityEngine;

public class Exit : MonoBehaviour
{
    public void OnQuitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
