using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOnCanvas : MonoBehaviour 
{
    public GameObject canvasPrefab;

    void Start()
    {
        canvasPrefab.SetActive(false);
    }

    void Update()
    {
        if (canvasPrefab != null && canvasPrefab.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
