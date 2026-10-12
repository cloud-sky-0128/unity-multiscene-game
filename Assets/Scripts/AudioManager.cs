using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip bgm; // 背景音乐
    public AudioClip seBubble; // 得到泡泡
    public AudioClip seBlock; // 放置区块
    public AudioClip seClick; // 点选功能
    public AudioClip seJump; // 向上跳
    public AudioClip seSuccess; // 成功吃完所有泡泡

    public List<AudioSource> audios = new List<AudioSource>();  // 声音播放器的清单

    private void Start()
    {
        ApplySettings();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            for (int i = 0; i < 6; i++)
            {
                var audio = this.gameObject.AddComponent<AudioSource>();
                audios.Add(audio);
            }

            audios[0].clip = bgm;
            audios[0].loop = true;
            audios[0].volume = 1.0f;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 根据特定的名称找到对应的音效片段
    AudioClip GetAudioClip(string name)
    {
        switch (name)
        {
            case "bgm":
                return bgm;
            case "seBubble":
                return seBubble;
            case "seBlock":
                return seBlock;
            case "seClick":
                return seClick;
            case "seJump":
                return seJump;
            case "seSuccess":
                return seSuccess;
        }
        return null;
    }

    // 播放指定音效
    public void Play(int index, string name, bool isloop)
    {
        var clip = GetAudioClip(name);
        if (clip != null)
        {
            var audio = audios[index];
            audio.clip = clip;
            audio.loop = isloop;
            audio.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip not found for name: " + name);
        }
    }

    // 手动播放 BGM
    public void PlayBGM()
    {
        var bgmAudio = audios[0];
        if (!bgmAudio.isPlaying)
        {
            bgmAudio.Play();
        }
    }

    // 停止播放 BGM
    public void StopBGM()
    {
        var bgmAudio = audios[0];
        if (bgmAudio.isPlaying)
        {
            bgmAudio.Stop();
        }
    }

    // 返回 BGM 音源
    public AudioSource GetBGMAudioSource()
    {
        return audios[0];
    }

    // 返回不包括 BGM 在内的音源
    public AudioSource[] GetSEAudioSources()
    {
        // 跳过第一个音源（假设第一个音源是 BGM）
        return audios.GetRange(1, audios.Count - 1).ToArray();
    }

    // Method to enable AudioManager
    public void EnableAudioManager()
    {
        this.gameObject.SetActive(true);
    }

    // Method to disable AudioManager
    public void DisableAudioManager()
    {
        this.gameObject.SetActive(false);
    }
    public void ApplySettings()
    {
        if (DataManager.instance != null)
        {
            var data = DataManager.instance;
            audios[0].volume = data.isBgmMuted ? 0 : data.bgmVolume;

            for (int i = 1; i < audios.Count; i++)
            {
                audios[i].volume = data.isSeMuted ? 0 : data.seVolume;
            }

            Debug.Log("Applied settings: BGM Volume: " + data.bgmVolume + ", SE Volume: " + data.seVolume);
        }
    }

}
    
