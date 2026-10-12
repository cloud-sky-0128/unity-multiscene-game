using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    void Update()
    {
        transform.position = GetClampedPosition(transform.position);
    }
    public Vector3 GetClampedPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        return position;
    }
}