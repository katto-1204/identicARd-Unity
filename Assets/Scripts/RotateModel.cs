using UnityEngine;

public class RotateModel : MonoBehaviour
{
    public float rotationSpeed = 3f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}