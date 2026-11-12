using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void LoadHomeScene(string home)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(home);
    }
    public void LoadLevelScene(string Level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Level);
    }
}
