using UnityEngine;

public class OrbitAroundTarget : MonoBehaviour
{
    [Header("Orbit Settings")]
    public float orbitSpeed = 60f;

    [Header("Car Facing")]
    public Transform carModel;
    public bool makeCarFaceDirection = true;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, orbitSpeed * Time.deltaTime, 0f);

        if (makeCarFaceDirection && carModel != null)
        {
            Vector3 moveDirection = carModel.position - lastPosition;

            if (moveDirection.sqrMagnitude > 0.0001f)
            {
                carModel.rotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);
            }

            lastPosition = carModel.position;
        }
    }
}