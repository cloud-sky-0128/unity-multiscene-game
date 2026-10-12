using UnityEngine;
using UnityEngine.UI;

public class SliderHandleController : MonoBehaviour
{
    public Slider slider; // 滑块
    public Image leftHandle; // 左侧 Handle 图像
    public Image rightHandle; // 右侧 Handle 图像
    public Sprite leftActiveImage; // 左侧激活图像
    public Sprite leftInactiveImage; // 左侧非激活图像
    public Sprite rightActiveImage; // 右侧激活图像
    public Sprite rightInactiveImage; // 右侧非激活图像

    void Start()
    {
        // 监听滑块值变化
        slider.onValueChanged.AddListener(UpdateHandleImages);
        // 初始更新一次图像
        UpdateHandleImages(slider.value);
    }

    void UpdateHandleImages(float value)
    {
        if (value < 0.5f)
        {
            leftHandle.sprite = leftActiveImage;
            rightHandle.sprite = rightInactiveImage;
        }
        else
        {
            leftHandle.sprite = leftInactiveImage;
            rightHandle.sprite = rightActiveImage;
        }
    }
}
