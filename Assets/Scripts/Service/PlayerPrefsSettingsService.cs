
using UnityEngine;

public class PlayerPrefsSettingsService : ISettingsService
{
    private const string SoundKey = "SoundOn";

    public bool SoundOn
    {
        get => PlayerPrefs.GetInt(SoundKey, 1) == 1;

        set
        {
            PlayerPrefs.SetInt(SoundKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
