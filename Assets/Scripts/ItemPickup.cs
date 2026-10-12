using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private PickupPromptManager promptManager;
    public GameObject manager;

    void Start()
    {
        promptManager = manager.GetComponent<PickupPromptManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptManager.ShowPickupPrompt(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptManager.HidePickupPrompt();
        }
    }
}