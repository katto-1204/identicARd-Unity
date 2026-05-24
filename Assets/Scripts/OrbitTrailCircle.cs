using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitTrailCircle : MonoBehaviour
{
    [Header("Circle Settings")]
    public float radius = 0.16f;
    public int segments = 96;
    public float yOffset = 0.012f;

    [Header("Glow Style")]
    public float lineWidth = 0.006f;
    public Color trailColor = new Color(1f, 0.2f, 0f, 1f);

    private LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        SetupLine();
        DrawCircle();
    }

    void OnValidate()
    {
        if (line == null)
        {
            line = GetComponent<LineRenderer>();
        }

        if (line != null)
        {
            SetupLine();
            DrawCircle();
        }
    }

    private void SetupLine()
    {
        line.useWorldSpace = false;
        line.loop = true;
        line.positionCount = segments;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = trailColor;
        line.endColor = trailColor;
    }

    private void DrawCircle()
    {
        if (segments < 3) segments = 3;

        for (int i = 0; i < segments; i++)
        {
            float angle = ((float)i / segments) * Mathf.PI * 2f;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            line.SetPosition(i, new Vector3(x, yOffset, z));
        }
    }
}