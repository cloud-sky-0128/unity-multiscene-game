using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endChange : MonoBehaviour
{
    public Button NextButton;

    void Start()
    {
        if (NextButton == null)
        {
            Debug.LogError("NextButton is not assigned in the Inspector.");
            return;
        }
        NextButton.onClick.AddListener(NextButtonPressed);
    }

    void NextButtonPressed()
    {
        // 加载名为 "end" 的场景
        SceneManager.LoadScene("end");
    }

}
