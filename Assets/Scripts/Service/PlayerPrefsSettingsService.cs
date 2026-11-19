using UnityEngine;

public class PlayerPrefsSettingsService : ISettingsService
{
    private const string SoundKey = "SoundOn";
    private const int SoundEnabled = 1;
    private const int SoundDisabled = 0;
    private const int DefaultSoundValue = SoundEnabled;

    public bool SoundOn
    {
        // the sound is enabled by default when no saved preference exists.
        get => PlayerPrefs.GetInt(SoundKey, DefaultSoundValue) == SoundEnabled;

        set
        {
            PlayerPrefs.SetInt(
                SoundKey,
                value ? SoundEnabled : SoundDisabled
            );
            PlayerPrefs.Save();
        }
    }
}
