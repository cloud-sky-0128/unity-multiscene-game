using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pappear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    public void appear(GameObject obj)
    {
        obj.SetActive(true);
    }
}
