
using UnityEngine;

public class CostumerManager : MonoBehaviour
{
    private RectTransform rectTransform;

    private float speed = 900f;

    private int flag = 0;

    private Vector2 firstPosition = new Vector2(371, -736);

    private Vector2[] path = new Vector2[]
    {
        new Vector2(371, 507),
        new Vector2(-335, 507),
        new Vector2(371, 507),
        new Vector2(371, -736)
    };

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Set the starting position
        rectTransform.anchoredPosition = firstPosition;
    }

    void Update()
    {
        // Move towards the current destination
        rectTransform.anchoredPosition = Vector2.MoveTowards(
            rectTransform.anchoredPosition,
            path[flag],
            speed * Time.deltaTime
        );

        // Check if the customer reached the destination
        if (Vector2.Distance(rectTransform.anchoredPosition, path[flag]) < 0.01f)
        {
            // Move to the next point
            flag++;

            // Restart the path when reaching the last point
            if (flag >= path.Length)
            {
                flag = 0;
            }

            // Rotate the customer
            switch (flag)
            {
                case 0:
                    rectTransform.rotation = Quaternion.Euler(0, 0, 90);
                    break;

                case 1:
                    rectTransform.rotation = Quaternion.Euler(0, 0, 180);
                    break;

                case 2:
                    rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                    break;

                case 3:
                    rectTransform.rotation = Quaternion.Euler(0, 0, 90);
                    break;
            }
        }
    }
}
