
using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    [SerializeField] private LevelManager levelManager;

    private void OnEnable()
    {
        if (levelManager != null)
        {
            levelManager.OnLevelChanged += UpdateLevelText;
        }
    }

    private void Start()
    {
        if (levelManager != null)
        {
            UpdateLevelText(levelManager.CurrentLevel);
        }
    }

    private void OnDisable()
    {
        if (levelManager != null)
        {
            levelManager.OnLevelChanged -= UpdateLevelText;
        }
    }

    private void UpdateLevelText(int level)
    {
        label.text = level.ToString();
    }
}
