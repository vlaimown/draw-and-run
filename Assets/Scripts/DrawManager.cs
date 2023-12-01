using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private Line linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line currentLine;

    public Vector3 screenPosition;
    public Vector3 worldPosition;
    void Start()
    {
        camera = Camera.main; 
    }

    void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (Input.GetMouseButtonDown(0) && IsMouseOverUI())
            currentLine = Instantiate(linePrefab, worldPosition, Quaternion.identity);

        if (Input.GetMouseButton(0) && IsMouseOverUI())
            currentLine.SetPosition(worldPosition);

        if (Input.GetMouseButtonUp(0) && currentLine != null)
            currentLine.SetLifeTime();
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
