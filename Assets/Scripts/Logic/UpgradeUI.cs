
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private CustomerPoolingSystem poolingSystem;

    private void Start()
    {
        RefreshButton();
    }

    public void Buy()
    {
        if (!upgradeManager.BuyUpgrade())
            return;

        poolingSystem.AddCustomer();

        upgradeButton.interactable = false;
        upgradeButton.image.color = Color.gray;
    }

    private void RefreshButton()
    {
        bool alreadyUpgraded = upgradeManager.CurrentLevel > 0;

        upgradeButton.interactable = !alreadyUpgraded;

        if (alreadyUpgraded)
            upgradeButton.image.color = Color.gray;
    }
}
