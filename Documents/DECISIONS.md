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