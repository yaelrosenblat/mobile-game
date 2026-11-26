
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    private void Start()
    {
        Show();
    }

    // Call this when the player completes a level.
    public void AddLevelReward()
    {
        const string rewardKey = "level_reward_claimed";

        if (Services.Save.GetInt(rewardKey, 0) == 1)
            return;

        int reward = Services.Config.Economy.coinsPerLevel;
        int currentCoins = Services.Save.GetInt("coins", 0);

        Services.Save.SetInt("coins", currentCoins + reward);
        Services.Save.SetInt(rewardKey, 1);

        Show();
    }

    // Call this when the player collects a daily gift.
    public void AddDailyGift()
    {
        int reward = Services.Config.Economy.dailyGift;
        int currentCoins = Services.Save.GetInt("coins", 0);

        Services.Save.SetInt("coins", currentCoins + reward);
        Show();
    }

    private void Show()
    {
        if (label != null)
            label.text = Services.Save.GetInt("coins", 0).ToString();
    }
}
