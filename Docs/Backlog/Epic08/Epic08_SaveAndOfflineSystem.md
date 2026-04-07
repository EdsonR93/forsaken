## Overview
Implement the save and offline systems for Forsaken. This epic establishes persistent save data, load behavior, offline earnings calculation, reward grant flow, and save validation so player progress can continue across sessions.

## Scope
Included:
- Save data model
- Save and load flow
- Offline earnings calculation
- Offline earnings grant flow
- Save state validation

Excluded:
- Cloud saves
- Cross device sync
- Save slot selection UI
- Offline reward ad boost
- Save file encryption hardening

## Acceptance Criteria
- [ ] The game can store core player progress in persistent save data
- [ ] Saved progress can be restored when the game starts
- [ ] Offline earnings can be calculated from elapsed time and game state
- [ ] Offline rewards can be granted safely after returning to the game
- [ ] Invalid or missing save data is handled safely
- [ ] The save and offline flow is reusable and testable

## Included Issues
- [ ] #43
- [ ] #44
- [ ] #45
- [ ] #46
- [ ] #47