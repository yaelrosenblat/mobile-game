# Little Grocery Store

Team: [Yael Rosenblat] · [Chen Weiss] · [May Solomon] Course: Mobile Game Development, Shenkar

# The game in one sentence

Managing a grocery store. Ensuring the shelves are full and the customers are satisfied

## Architecture

```mermaid
flowchart TD
    A["Bootstrap Scene"] --> B["Initialize PlayerPrefsSaveService"]
    B --> C["Initialize PlayerPrefsSettingsService"]
    C --> D["Load Home Scene"]

    D --> E["Game Assembly"]
    E --> F["Customer Systems"]
    E --> G["CoinCounter and UI"]
    E --> H["Level Management"]

    E --> I["Services Assembly"]
    I --> J["ISaveService"]
    I --> K["ISettingsService"]
    I --> L["PlayerPrefs Implementations"]

    E -. "Access through Services" .-> I
```

## Assembly Structure

- **Game**: Gameplay, customer systems, UI, and level management.
- **Services**: Save and settings interfaces and their implementations.
- Game references Services.
- Services does not reference Game.

## Startup Flow

1. Unity opens the Bootstrap scene first.
2. Bootstrap initializes `PlayerPrefsSaveService`.
3. Bootstrap initializes `PlayerPrefsSettingsService`.
4. Bootstrap loads the Home scene.
5. Gameplay systems access services through the `Services` class.


## Economy Sheet

Our economy configuration includes:
- Level completion rewards
- Daily gifts
- Upgrade costs and progression
- Customer capacity upgrades

[View Little Grocery Store Economy Sheet](https://docs.google.com/spreadsheets/d/11UQHof8FsOIq1-wzbGSrVRxJUgRclG8tPhEiRDfmBps/edit?usp=sharing)

Economy balance check: Yes
Economy progression check: Yes