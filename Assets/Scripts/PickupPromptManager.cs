using UnityEngine;
using UnityEngine.UI;

public class PickupPromptManager : MonoBehaviour
{
    public GameObject pickupPanel; // 提示窗口的Panel
    public Text pickupText; // 提示消息的Text
    private GameObject currentItem; // 當前碰到的物品
    private PlayerScore playerScore;

    void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
        pickupPanel.SetActive(false); // 初始設置為不激活
    }

    public void ShowPickupPrompt(GameObject item)
    {
        currentItem = item;
        pickupText.text = "要撿起這個物品嗎？";
        pickupPanel.SetActive(true);
    }

    public void HidePickupPrompt()
    {
        pickupPanel.SetActive(false);
        currentItem = null;
    }

    public void OnPickupButton()
    {
        if (currentItem != null)
        {
            Debug.Log("物品已撿起: " + currentItem.name);
            Destroy(currentItem);
            HidePickupPrompt();
            playerScore.DamegePlayer(50);
        }
    }

    public void OnCancelButton()
    {
        HidePickupPrompt();
    }
}