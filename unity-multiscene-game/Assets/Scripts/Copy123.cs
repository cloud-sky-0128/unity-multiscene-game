using UnityEngine;

public class Copy123 : MonoBehaviour
{
    public GameObject objectToCopy;

    private void Start()
    {
        objectToCopy.SetActive(false);
    }

    public void CopyObject()
    {
        objectToCopy.SetActive(true);
    }
}
