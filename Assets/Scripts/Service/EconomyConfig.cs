using UnityEngine;

[CreateAssetMenu(menuName = "Game/Economy Config")]

public class EconomyConfig : ScriptableObject
{
    [Header("Sources")]
    public int coinsPerLevel = 50;
    public int dailyGift = 50;

    [Header("Upgrade, the big sink")]
    public int upgradeBaseCost = 100;
    public float upgradeGrowth = 1.5f;
    public int upgradeMaxLevel = 10;

    [Header("Customer Upgrade")]
    public int customersPerUpgrade = 1;

    // Price of the next upgrade: base × growth, once per level bought. Same as the sheet.
    public int UpgradeCost(int level) =>
        Mathf.RoundToInt(upgradeBaseCost * Mathf.Pow(upgradeGrowth, level));


}
