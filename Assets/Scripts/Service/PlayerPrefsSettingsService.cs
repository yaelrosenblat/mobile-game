
using UnityEngine;

public class PlayerPrefsSettingsService : ISettingsService
{
    private const string SoundKey = "SoundOn";

    public bool SoundOn
    {
        // the sound is enabled by default when no saved preference exists.
        get => PlayerPrefs.GetInt(SoundKey, 1) == 1;

        set
        {
            PlayerPrefs.SetInt(SoundKey, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
