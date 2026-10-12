using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenemanager : MonoBehaviour 
{
    // Start is called before the first frame update
    private Game_SettingsManager settingsManager;
    void Start()
    {
        var audioManager = AudioManager.instance;
        if (audioManager != null)
        {
            audioManager.EnableAudioManager(); 
            audioManager.ApplySettings();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
