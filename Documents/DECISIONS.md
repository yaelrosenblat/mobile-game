## 2026-11-04 — Choose a hybrid-casual supermarket simulator
**Options:** Simulation, Puzzle game, Hybrid-casual supermarket simulator

**Chose:** Hybrid-casual supermarket simulator: players manage a grocery store by completing short mini-games to restock shelves, satisfy customers, and earn rewards.

**Why:** Combines simple, quick gameplay with long-term progression through leveling up, unlocking products, and expanding the supermarket.

**AI:** Used ChatGPT to help refine the game concept, core loop, meta, goals, and player experience.

**Who:** Yael Rosenblat, Chen Weiss, May Solomon

## 2026-11-19 — Separate save and settings services

**Options:** Access PlayerPrefs directly from gameplay scripts; create separate service interfaces and implementations.

**Chose:** Use `ISaveService` and `ISettingsService` in a dedicated Services assembly, with `PlayerPrefsSaveService` and `PlayerPrefsSettingsService` as their implementations. Bootstrap initializes both services before loading the Home scene.

**Why:** Keeps gameplay code independent of PlayerPrefs, makes saving and settings easier to maintain or replace, and enforces a clear boundary between the Game and Services assemblies.

**AI:** Used ChatGPT to help plan the service architecture and implementation.

**Who:** Yael Rosenblat, Chen Weiss, May Solomon.


## 2026-11-26 — Manage economy values through a configuration service

**Options:** Hardcode economy values (rewards, upgrade prices, and progression numbers) in gameplay scripts; store economy values in a separate configuration asset accessed through a dedicated service.

**Chose:** Use an `EconomyConfig` ScriptableObject to store economy values and an `IConfigService` to provide access to the configuration through `Services.Config.Economy`. Bootstrap initializes the configuration service after the Save service.

**Why:** Keeps economy numbers in one central location instead of spreading them across gameplay scripts. This makes balancing and adjusting the game's economy easier without changing gameplay code. It also keeps the architecture organized by separating configuration data from game logic.

**AI:** Used ChatGPT to help document and explain the configuration service architecture decision.

**Who:** Yael Rosenblat, Chen Weiss, May Solomon.