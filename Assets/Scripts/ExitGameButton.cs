using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
    // 這個方法會在按鈕被點擊時調用
    public void ExitGame()
    {
        // 在 Unity 編輯器中進行測試時，會顯示一條日誌消息
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // 在已構建的遊戲中，會退出遊戲
        Application.Quit();
        #endif
    }
}