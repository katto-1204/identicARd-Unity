using UnityEngine;

public class SimpleCarOrbit : MonoBehaviour
{
    public float orbitSpeed = 50f;

    void Update()
    {
        transform.Rotate(0f, orbitSpeed * Time.deltaTime, 0f);
    }
}