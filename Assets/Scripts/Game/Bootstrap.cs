using UnityEngine;
using UnityEngine.SceneManagement;


// The only script in the Bootstrap scene, the first scene in the Scene List.
public class Bootstrap : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(gameObject);       // Services survives every scene change

        // Start every service here, in order (next follow-along)

                // Initialize services in order
        Services.Save = new PlayerPrefsSaveService();
        Services.Settings = new PlayerPrefsSettingsService();

        //Services.Save = new PlayerPrefsSaveService();
        SceneManager.LoadScene("Home");      // only now: the first screen
    }

}
