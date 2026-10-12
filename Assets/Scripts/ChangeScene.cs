using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {
    public string SceneName; // 目標場景的名稱

    void Start() {
        this.transform.tag = "";
    }

    public void ChangeScene() {
        SceneManager.LoadScene(SceneName);
    }
}