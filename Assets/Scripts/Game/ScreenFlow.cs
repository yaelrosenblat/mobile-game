using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFlow : MonoBehaviour
{

    [SerializeField] private GameObject upgradeShopPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleUpgradeShop()
    {
        if (upgradeShopPopup != null)
        {
            upgradeShopPopup.SetActive(!upgradeShopPopup.activeSelf);
        }
        else
        {
            Debug.LogError("Upgrade shop popup is not assigned!");
        }
    }
}
