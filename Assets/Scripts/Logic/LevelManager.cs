
using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string LevelKey = "Level";

    public int CurrentLevel { get; private set; }

    public event Action<int> OnLevelChanged;

    private void Awake()
    {
        CurrentLevel = Mathf.Max(
            1,
            Services.Save.GetInt(LevelKey, 1)
        );
    }

    public void LevelUp()
    {
        CurrentLevel++;

        Services.Save.SetInt(LevelKey, CurrentLevel);
        Services.Save.SetInt("level_reward_claimed", 0);
        OnLevelChanged?.Invoke(CurrentLevel);


    }
}
