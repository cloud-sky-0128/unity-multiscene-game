using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private AreaEffector2D areaEffector;
    public int force;
    void Start()
    {
        arrow.SetActive(false);
        areaEffector = arrow.GetComponent<AreaEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeMagnitude(int cforce)
    {
        force = cforce;
        Debug.Log("force111: " + force);
        areaEffector.forceMagnitude = cforce;
        Debug.Log("areaEffector111: " + areaEffector.forceMagnitude);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 檢查碰撞對象是否有 "Player" 標籤
        if (other.gameObject.CompareTag("Player"))
        {
            arrow.SetActive(true);
            areaEffector.forceMagnitude = force;
            Debug.Log("force: " + force);
            Debug.Log("areaEffector: " + areaEffector.forceMagnitude);
        }
    }
}