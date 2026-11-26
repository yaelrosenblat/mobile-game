using UnityEngine;
using UnityEngine.SceneManagement;


// The only script in the Bootstrap scene, the first scene in the Scene List.
public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EconomyConfig economyConfig;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);       // Services survives every scene change

        // Initialize services in order
        Services.Save = new PlayerPrefsSaveService();
        if (economyConfig == null)
        {
            Debug.LogError("EconomyConfig is missing in Bootstrap!");
            return;
        }
        Services.Config = new ConfigService(economyConfig);
        Debug.Log("Economy reward: " + Services.Config.Economy.coinsPerLevel);
        Services.Settings = new PlayerPrefsSettingsService();

        //Services.Save = new PlayerPrefsSaveService();
        SceneManager.LoadScene("home");      // only now: the first screen
    }

}
