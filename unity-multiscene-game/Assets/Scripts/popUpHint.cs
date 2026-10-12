using UnityEngine;
using UnityEngine.UI;

public class popUpHint : MonoBehaviour
{
    public GameObject hint;  // 参考提示窗口
    public Button hintButton;     // 参考显示提示的按钮
    public Button closeButton;    // 参考关闭提示的按钮

    void Start()
    {
        // 为按钮添加监听事件
        hintButton.onClick.AddListener(ShowHint);
        closeButton.onClick.AddListener(HideHint);
    }

    // 显示提示窗口
    public void ShowHint()
    {
        hint.SetActive(true);
    }

    // 隐藏提示窗口
    public void HideHint()
    {
        hint.SetActive(false);
    }
}
