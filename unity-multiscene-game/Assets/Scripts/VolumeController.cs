using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public Button muteButton;
    public Sprite muteImage;
    public Sprite unmuteImage;
    private AudioSource[] audioSources;

    private bool isMuted = false;
    private float previousVolume = 1f;

    public AudioManager audioManager;

    void Start()
    {

        audioManager = FindObjectOfType<AudioManager>();
        audioSources = audioManager.GetSEAudioSources();

        ApplySavedSettings();

        volumeSlider.onValueChanged.AddListener(ChangeVolume);
        muteButton.onClick.AddListener(ToggleMute);
        UpdateMuteButtonImage();
    }

    private void ApplySavedSettings()
    {
        if (DataManager.instance != null)
        {
            isMuted = DataManager.instance.isSeMuted;
            previousVolume = DataManager.instance.seVolume;

            if (isMuted)
            {
                SetVolume(0);
                volumeSlider.value = 0;
            }
            else
            {
                SetVolume(previousVolume);
                volumeSlider.value = previousVolume;
            }
        }
    }


    private void SetVolume(float value)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = value;
        }
    }

    public void ChangeVolume(float value)
    {
        SetVolume(value);
        if (value > 0)
        {
            previousVolume = value;
            isMuted = false;
        }
        else
        {
            isMuted = true;
        }
        DataManager.instance?.SaveAudioSettings(DataManager.instance.bgmVolume, value, DataManager.instance.isBgmMuted, isMuted);
        UpdateMuteButtonImage();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            SetVolume(0);
            volumeSlider.value = 0;
        }
        else
        {
            SetVolume(previousVolume);
            volumeSlider.value = previousVolume;
        }
        DataManager.instance?.SaveAudioSettings(DataManager.instance.bgmVolume, previousVolume, DataManager.instance.isBgmMuted, isMuted);
        UpdateMuteButtonImage();
    }

    private void UpdateMuteButtonImage()
    {
        if (isMuted)
        {
            muteButton.image.sprite = muteImage;
        }
        else
        {
            muteButton.image.sprite = unmuteImage;
        }
    }
}
