using UnityEngine;
using UnityEngine.UI;

public class BGM_VolumeController : MonoBehaviour
{
    public Slider bgm_volumeSlider;  // 音量滑块
    private AudioSource bgm_audioSource;  // 音乐音源
    public Button bgm_MuteButton;  // 静音按钮
    public Sprite muteImage; // 静音图标
    public Sprite unmuteImage; // 取消静音图标

    private float previousVolume = 1f;  // 记录之前的音量
    private bool isMuted = false; // 记录是否静音

    // 引用 AudioManager
    public AudioManager audioManager;

    void Start()
    {
        // 获取 AudioManager 中的 BGM 音源
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            bgm_audioSource = audioManager.GetBGMAudioSource(); // 假设 BGM 是第一个 AudioSource
            ApplySavedSettings();
        }

        // 监听滑块值变化
        bgm_volumeSlider.onValueChanged.AddListener(ChangeVolume);
        // 监听静音按钮点击事件
        bgm_MuteButton.onClick.AddListener(ToggleMute);
        // 设置静音按钮初始图标
        UpdateMuteButtonImage();
    }

    private void ApplySavedSettings()
    {
        // 从 DataManager 加载设置
        if (DataManager.instance != null)
        {
            bgm_audioSource.volume = DataManager.instance.bgmVolume;
            isMuted = DataManager.instance.isBgmMuted;
            if (isMuted)
            {
                bgm_audioSource.Pause();
                bgm_volumeSlider.value = 0;
            }
            else
            {
                bgm_audioSource.UnPause();
                bgm_volumeSlider.value = bgm_audioSource.volume;
            }
        }
    }

    public void ChangeVolume(float value)
    {
        bgm_audioSource.volume = value;
        if (value > 0)
        {
            previousVolume = value;
            isMuted = false;
        }
        else
        {
            isMuted = true;
        }
        DataManager.instance?.SaveAudioSettings(bgm_audioSource.volume, DataManager.instance.seVolume, isMuted, DataManager.instance.isSeMuted);
        UpdateMuteButtonImage();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            previousVolume = bgm_audioSource.volume;
            bgm_audioSource.Pause();
            bgm_volumeSlider.value = 0;
        }
        else
        {
            bgm_audioSource.UnPause();
            bgm_volumeSlider.value = previousVolume;
            bgm_audioSource.volume = previousVolume;
        }
        DataManager.instance?.SaveAudioSettings(bgm_audioSource.volume, DataManager.instance.seVolume, isMuted, DataManager.instance.isSeMuted);
        UpdateMuteButtonImage();
    }

    // 更新静音按钮图标
    private void UpdateMuteButtonImage()
    {
        if (isMuted)
        {
            bgm_MuteButton.image.sprite = muteImage;
        }
        else
        {
            bgm_MuteButton.image.sprite = unmuteImage;
        }
    }
}
