using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private GameObject drawPanel;

    private Camera camera;
    private Player player;

    [SerializeField] private Line linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line currentLine;

    private Vector3 screenPosition;
    private Vector3 worldPosition;

    [SerializeField] private float drawPanelMinX;
    [SerializeField] private float drawPanelMinY;
    [SerializeField] private float drawPanelMaxX;
    [SerializeField] private float drawPanelMaxY;
    void Start()
    {
        camera = Camera.main; 
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //Debug.Log(worldPosition);

        if (Input.GetMouseButtonDown(0) && IsMouseOverUI())
        {
            currentLine = Instantiate(linePrefab, worldPosition, Quaternion.identity);
            //currentLine.transform.SetParent(drawPanel.transform);
        }

        if (Input.GetMouseButton(0) && IsMouseOverUI())
            currentLine.SetPosition(worldPosition);

        if (Input.GetMouseButtonUp(0) && currentLine != null)
        {
            List<Vector3> pointsToMove = new List<Vector3>();

            int pointCount = currentLine.PositionCount();
            int heroCount = player.HeroListCount();

            int interval = 0;

            if (pointCount > heroCount)
            {
                interval = Mathf.Abs(pointCount / heroCount);
            }
            else
            {
                interval = Mathf.Abs(heroCount / pointCount);
            }

            for (int i = 0; i < pointCount; i++)
            {
                if (interval != 0)
                {
                    if (i / interval == 0)
                    {
                        Vector3 pointToMove = currentLine.LinePointPos(i);

                        pointToMove.x = (drawPanelMaxX - pointToMove.x) / (drawPanelMaxX - drawPanelMinX);
                        pointToMove.y = (drawPanelMaxY - pointToMove.y) / (drawPanelMaxY - drawPanelMinY);
;
                        pointsToMove.Add(pointToMove);
                    }
                }
            }

            for (int i = 0; i < pointsToMove.Count; i++)
            {
                Debug.Log(pointsToMove[i]);
            }

            currentLine.SetLifeTime();
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
