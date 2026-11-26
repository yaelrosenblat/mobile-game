
using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CustomerMovement : MonoBehaviour
{

    [Header("Appearance")]
    [SerializeField] private float customerWidth = 100f;
    [SerializeField] private float customerHeight = 150f;

    [Header("Movement")]
    [SerializeField, Min(1f)]

    private float speed = 400f;
    private float pauseDuration;

    private RectTransform rectTransform;
    private Transform parentTransform;

    private RectTransform[] currentPath;

    private int currentPoint;
    private bool isMoving;

    private int pausePoint = -1;
    private float pauseRemaining;

    public event Action RouteCompleted;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentTransform = rectTransform.parent;
        ApplySize();
    }

    private void ApplySize()
    {
        rectTransform.sizeDelta = new Vector2(
            customerWidth,
            customerHeight
        );
    }

    public void StartRoute(
        RectTransform[] path,
        int pauseAtPoint = -1,
        float waitSeconds = 0f)
    {
        if (path == null || path.Length < 2)
        {
            Debug.LogError(
                "CustomerMovement: Invalid path."
            );
            return;
        }

        foreach (RectTransform point in path)
        {
            if (point == null)
            {
                Debug.LogError(
                    "CustomerMovement: Missing waypoint."
                );
                return;
            }
        }

        parentTransform = rectTransform.parent;

        if (parentTransform == null)
        {
            Debug.LogError(
                "CustomerMovement: Missing parent."
            );
            return;
        }

        currentPath = path;
        currentPoint = 1;

        pausePoint = pauseAtPoint;
        pauseDuration = Mathf.Max(0f, waitSeconds);
        pauseRemaining = 0f;

        // Convert start point to parent-local coordinates
        Vector3 startPosition =
            parentTransform.InverseTransformPoint(
                path[0].position
            );

        rectTransform.localPosition = startPosition;
        isMoving = true;
    }

    private void Update()
    {
        if (!isMoving)
            return;

        if (pauseRemaining > 0f)
        {
            pauseRemaining -= Time.deltaTime;
            return;
        }

        // Convert waypoint to parent-local coordinates
        Vector3 target =
            parentTransform.InverseTransformPoint(
                currentPath[currentPoint].position
            );

        // Move in local UI coordinates
        rectTransform.localPosition = Vector3.MoveTowards(
            rectTransform.localPosition,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(
            rectTransform.localPosition,
            target) > 0.01f)
        {
            return;
        }

        int reachedPoint = currentPoint;
        currentPoint++;

        if (currentPoint >= currentPath.Length)
        {
            isMoving = false;
            RouteCompleted?.Invoke();
            return;
        }

        if (reachedPoint == pausePoint)
        {
            pauseRemaining = pauseDuration;
        }
    }

    private void OnDisable()
    {
        isMoving = false;
        currentPath = null;
    }
}
