using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class floatingPlatformStop : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;

    private int i;
    public bool condition = false;

    void Start()
    {
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(condition){
            transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
            {
                if (waitTime < 0.0f)
                {
                    i = (i == 0) ? 1 : 0;
                    waitTime = 0.5f;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}