
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private CoinCounter coinCounter;

    private void Start()
    {
        Refresh();
    }

    public void Buy()
    {
        if (upgradeManager.BuyUpgrade())
        {
            Refresh();
            coinCounter.SendMessage("Show", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void Refresh()
    {
        if (upgradeManager.CurrentLevel >= Services.Config.Economy.upgradeMaxLevel)
        {
            priceText.text = "MAX LEVEL";
            buttonText.text = "MAX LEVEL";
            return;
        }

        priceText.text = "Cost: " + upgradeManager.GetNextUpgradeCost();
        buttonText.text = "BUY UPGRADE";
    }
}
