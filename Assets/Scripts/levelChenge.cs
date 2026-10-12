using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChenge : MonoBehaviour
{
    public GameObject game1, game2, game3, game4, game5;
    public PlayerScore playerScore; // 修改為私有變數
    //public GameObject obj;
    //private copyFunction copyFunction;
    

    // Start is called before the first frame update
    void Start()
    {
        playerScore = GameObject.Find("Player").GetComponent<PlayerScore>(); // 動態獲取 PlayerScore 組件
        //copyFunction = obj.GetComponent<copyFunction>();
        game1.SetActive(true);
        game2.SetActive(false);
        game3.SetActive(false);
        game4.SetActive(false);
        game5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore != null)
        {
            switch(playerScore.score)
            {
                case 0:
                    game1.SetActive(true);
                    game2.SetActive(false);
                    game3.SetActive(false);
                    game4.SetActive(false);
                    game5.SetActive(false);
                    //copyFunction.appear(obj);
                    Debug.Log("1");
                    break;
                case 20:
                    game1.SetActive(false);
                    game2.SetActive(true);
                    game3.SetActive(false);
                    game4.SetActive(false);
                    game5.SetActive(false);
                    //copyFunction.appear(obj);
                    Debug.Log("2");
                    break;
                case 40:
                    game1.SetActive(false);
                    game2.SetActive(false);
                    game3.SetActive(true);
                    game4.SetActive(false);
                    game5.SetActive(false);
                    //copyFunction.appear(obj);
                    Debug.Log("3");
                    break;
                case 60:
                    game1.SetActive(false);
                    game2.SetActive(false);
                    game3.SetActive(false);
                    game4.SetActive(true);
                    game5.SetActive(false);
                    //copyFunction.appear(obj);
                    Debug.Log("4");
                    break;
                case 80:
                    game1.SetActive(false);
                    game2.SetActive(false);
                    game3.SetActive(false);
                    game4.SetActive(false);
                    game5.SetActive(true);
                    //copyFunction.appear(obj);
                    Debug.Log("5");
                    break;
            }
        }
        else
        {
            Debug.LogError("PlayerScore component not found!");
        }
    }
}
