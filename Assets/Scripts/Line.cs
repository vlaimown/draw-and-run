using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float maxLifeTime = 1f;
    private float currentLifeTime;
    private bool drawn = false;

    private void Update()
    {
        if (drawn)
        {
            if (currentLifeTime > 0)
                currentLifeTime -= Time.deltaTime;
            if (currentLifeTime <= 0)
                Destroy(gameObject);
        }
    }

    public void SetPosition(Vector3 pos)
    {
        if (!CanAppend(pos))
            return;

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, pos);
    }

    private bool CanAppend(Vector3 pos)
    {
        if (lineRenderer.positionCount == 0)
            return true;

        return Vector3.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public void SetLifeTime()
    {
        currentLifeTime = maxLifeTime;
        drawn = true;
    }

    public int PositionCount() => lineRenderer.positionCount;

    public Vector3 LinePointPos(int index) => lineRenderer.GetPosition(index);

    public int GetDirection() 
    {
        if (lineRenderer.GetPosition(0).x >= 0)
            return 1;
        else
            return -1;
    }
}
