using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TestClick : MonoBehaviour
{
    public Text NumOfFor;
    public string SceneName;

    void Start()
    {
        this.transform.tag = "";
    }
    public void EnterNumOfFor(Text enterText)
    {
        NumOfFor.text = enterText.text;
        if(NumOfFor.text != "-")
        {
            PlayerPrefs.SetString("NumOfFor", NumOfFor.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneName);
        }
    }
}
