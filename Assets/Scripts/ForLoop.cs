using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ForLoop : MonoBehaviour
{
    public Text displayText;
    public GameObject virus;
    public float waitTime;
    public Transform xmin;
    public Transform xmax;

    private int numOfFor;
    private float wait;
    private Boundaries boundaries;

    // Start is called before the first frame update
    void Start()
    {
        boundaries = GameObject.FindGameObjectWithTag("Player").GetComponent<Boundaries>();
        wait = waitTime;
        if (PlayerPrefs.HasKey("NumOfFor"))
        {
            string numOfForText = PlayerPrefs.GetString("NumOfFor");
            displayText.text = numOfForText;
            if (int.TryParse(numOfForText, out numOfFor))
            {
                Debug.Log("NumOfFor as integer: " + numOfFor);
            }
            else
            {
                Debug.LogWarning("Failed to convert NumOfFor to an integer.");
            }
        }
    }

    void Update()
    {
        if (numOfFor > 0)
        {
            if (waitTime <= 0)
            {
                numOfFor--;
                waitTime = wait;
                displayText.text = "" + numOfFor;
                Instantiate(virus, GetRandomPos(), transform.rotation);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (numOfFor == 0)
        {
            displayText.gameObject.SetActive(false);
            boundaries.enabled = false;
            numOfFor--;
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(xmin.position.x, xmax.position.x), xmin.position.y);
        return rndPos;
    }
}
