using UnityEngine;

public class CopyObjectOnDrop : MonoBehaviour
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
