using UnityEngine;

public class LineManager : MonoBehaviour
{
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw(Vector3 startPos, Vector3 dir)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, startPos + dir);
    }

    public void Clear()
    {
        lineRenderer.positionCount = 0;
    }
}
