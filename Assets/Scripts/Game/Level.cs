using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] TMP_Text label;
    void Start() => Show();

    void Show() => label.text = Services.Save.GetInt("Level").ToString();
}
