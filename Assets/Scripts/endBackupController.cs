using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class endBackupController : MonoBehaviour
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
        // fs.RegisterCommand("load_sence",(List<string> _params)=>{
        //     SceneManager.LoadScene(_params[0]);
        // });
        
    }

    private bool isGameEnd = false;
    private int progress = 0;

    void Update()
    {
        if(fs.isCompleted && !isGameEnd){
            switch(progress){
                case 1:
                    fs.ReadTextFromResource("endForBackup");
                    break;
                case 2:
                    isGameEnd = true;
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
        if (isGameEnd){
            Debug.Log("Game end, loading Start scene");
            LoadScene("Start");
        }
    }

    private void LoadScene(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        // 销毁所有 DontDestroyOnLoad 的对象
        DestroyAllDontDestroyOnLoadObjects();
        // 加载新场景
        SceneManager.LoadScene(sceneName);
    }

    private void DestroyAllDontDestroyOnLoadObjects()
    {
        // 获取当前场景
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();

        // 获取所有根对象
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // 销毁不属于当前场景的对象
        foreach (GameObject go in allObjects)
        {
            if (go.scene != currentScene && !string.IsNullOrEmpty(go.scene.name))
            {
                Destroy(go);
            }
        }
    }
}
