using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwItem : MonoBehaviour
{
    public GameObject computer; // �n�ͦ�������]�Ҧp�q���^���w�s��
    public int quantity;

    void Start()
    {

    }

    void Update()
    {
        // �ˬd�O�_���U "O" ��
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // �ͦ����w������]�q���w�s��^�A��m�M����P���e����ۦP
            Instantiate(computer, transform.position, transform.rotation);
            quantity--;
        }
    }
}
