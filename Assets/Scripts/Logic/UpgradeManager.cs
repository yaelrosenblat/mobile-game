using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private const string UpgradeKey = "upgrade_level";
    private const string CoinsKey = "coins";

    public int CurrentLevel { get; private set; }

    private void Start()
    {
        CurrentLevel = Services.Save.GetInt(UpgradeKey, 0);
    }

    public int GetNextUpgradeCost()
    {
        return Services.Config.Economy.UpgradeCost(CurrentLevel);
    }

    public bool BuyUpgrade()
    {
        int coins = Services.Save.GetInt(CoinsKey, 0);
        int cost = GetNextUpgradeCost();

        if (CurrentLevel >= Services.Config.Economy.upgradeMaxLevel)
            return false;

        if (coins < cost)
            return false;

        Services.Save.SetInt(CoinsKey, coins - cost);

        CurrentLevel++;
        Services.Save.SetInt(UpgradeKey, CurrentLevel);

        return true;
    }
}
