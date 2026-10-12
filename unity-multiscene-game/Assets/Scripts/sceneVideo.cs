using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneVideoManager : MonoBehaviour
{
    public string sceneName;
    public float playDuration = 3.0f;

    private VideoPlayer videoPlayer;
    private float timer = 0f;  // 明確初始化為 0
    private int playCount = 0; // 播放次數計數器
    private bool isPlaying = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component is missing.");
            return;
        }

        videoPlayer.isLooping = false; // 不循環播放
        videoPlayer.loopPointReached += OnVideoFinished; // 註冊影片播放完成事件
        PlayVideo();
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;

            if (timer >= playDuration)
            {
                videoPlayer.Stop();
                isPlaying = false;
                OnVideoFinished(videoPlayer); // 模擬影片播放結束
            }
        }
    }

    void PlayVideo()
    {
        videoPlayer.Play();
        isPlaying = true;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        playCount++;
        timer = 0f; // 重置計時器

        if (playCount >= 3)
        {
            LoadNextScene();
        }
        else
        {
            PlayVideo();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}