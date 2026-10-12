using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class IntroSenceController : MonoBehaviour
{
    FlowerSystem fs;
    GameObject defaultUIStagePrefab;
    GameObject flowerimagenight;
    GameObject floweraudiobgm;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.SetupUIStage();
        fs.RegisterCommand("load_sence",(List<string> _params)=>{
            HideDefaultDialogPrefab();
            defaultUIStagePrefab = GameObject.Find("DefaultUIStagePrefab(Clone)");
            if (defaultUIStagePrefab != null)
            {
                defaultUIStagePrefab.SetActive(false); // 隐藏 DefaultUIStagePrefab
            }
            flowerimagenight = GameObject.Find("flower-image-night");
            if (flowerimagenight != null)
            {
                flowerimagenight.SetActive(false); // 隐藏 DefaultUIStagePrefab
            }
            floweraudiobgm = GameObject.Find("flower-audio-bgm");
            if (floweraudiobgm != null)
            {
                floweraudiobgm.SetActive(false); // 隐藏 DefaultUIStagePrefab
            }
            SceneManager.LoadScene(_params[0]);
        });
        var audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.DisableAudioManager(); // 禁用 AudioManager
        }
        // 查找并隐藏 DefaultDialogPrefab
        
    }

    private bool isGameEnd = false;
    private int progress = 0;
    private bool buttonCreated = false;

    void Update()
    {
        if(fs.isCompleted && !isGameEnd && !buttonCreated){
            switch(progress){
                case 0:
                    fs.ReadTextFromResource("intro");
                    Debug.Log("progress: "+progress);
                    break;
                case 1:
                    fs.SetupButtonGroup();
                    fs.SetupButton("起床去上課",()=>{
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("class");
                        fs.Resume();
                        buttonCreated=false;
                    });
                    fs.SetupButton("再睡五分鐘",()=>{
                        fs.RemoveButtonGroup();
                        fs.ReadTextFromResource("notclass");
                        fs.Resume();
                        buttonCreated=false;
                    });
                    buttonCreated=true;
                    break;
                case 2:
                    isGameEnd=true;
                    break;
            }
            progress++;
        }

        if (!isGameEnd)
        {
            if(Input.GetKeyDown(KeyCode.Space)){
                fs.Next();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                fs.Resume();
            }
        }
    }

    // 在需要时隐藏 DefaultDialogPrefab
    void HideDefaultDialogPrefab()
    {
        GameObject defaultDialogPrefab = GameObject.Find("DefaultDialogPrefab(Clone)");
        if (defaultDialogPrefab != null)
        {
            defaultDialogPrefab.SetActive(false); // 隐藏 DefaultDialogPrefab
        }
    }
    void OnDestroy()
    {
        // 销毁 Flower 系统所在的 GameObject
        if (fs != null)
        {
            Destroy(fs.gameObject);
        }
    }
}
