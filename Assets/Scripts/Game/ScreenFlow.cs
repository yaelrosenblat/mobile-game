using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFlow : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PopUpControll(string popUpName)
    {
        GameObject popUp = GameObject.Find(popUpName);
        if (popUp != null)
        {
            popUp.SetActive(!popUp.activeSelf);
        }
    }
}
