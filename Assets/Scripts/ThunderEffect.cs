using UnityEngine;

public class ThunderEffect : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float lifeTime = 0.3f;

    public void Setup(Vector3 targetPosition)
    {
        Vector3 startPosition = targetPosition + Vector3.up * 8f;
        Vector3 endPosition = targetPosition;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);

        Destroy(gameObject, lifeTime);
    }
}