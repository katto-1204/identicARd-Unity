using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatSpeed = 1.5f;
    public float floatAmount = 0.015f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmount;
        transform.localPosition = new Vector3(startPosition.x, newY, startPosition.z);
    }
}