
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
    private RectTransform panel;

    private Rect lastSafeArea;
    private Vector2Int lastScreenSize;

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    private void Start()
    {
        UpdateSafeArea();
    }

    private void Update()
    {
        Rect currentSafeArea = Screen.safeArea;

        Vector2Int currentScreenSize = new Vector2Int(
            Screen.width,
            Screen.height
        );

        if (currentSafeArea != lastSafeArea ||
            currentScreenSize != lastScreenSize)
        {
            UpdateSafeArea();
        }
    }

    private void UpdateSafeArea()
    {
        if (Screen.width <= 0 || Screen.height <= 0)
            return;

        Rect safe = Screen.safeArea;

        lastSafeArea = safe;

        lastScreenSize = new Vector2Int(
            Screen.width,
            Screen.height
        );

        Vector2 anchorMin = new Vector2(
            safe.xMin / Screen.width,
            safe.yMin / Screen.height
        );

        Vector2 anchorMax = new Vector2(
            safe.xMax / Screen.width,
            safe.yMax / Screen.height
        );

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;

        panel.anchoredPosition = Vector2.zero;
        panel.offsetMin = Vector2.zero;
        panel.offsetMax = Vector2.zero;

        /*Debug.Log(
            $"SafeArea updated: " +
            $"Screen={Screen.width}x{Screen.height}, " +
            $"Min={anchorMin}, Max={anchorMax}"
        );*/
    }
}
