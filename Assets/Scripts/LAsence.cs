using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
public class LAsence : MonoBehaviour
{
    // Start is called before the first frame update
    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.GetFlowerSystem("default");
        fs.ReadTextFromResource("class");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            fs.Next();
        }
    }
}
