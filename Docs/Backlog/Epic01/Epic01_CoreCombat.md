## Overview
Implement the core combat loop for Forsaken. This epic establishes automatic player attacks, enemy targeting, damage calculation, and critical hit handling so the game has a playable combat foundation.

## Scope
Included:
- Player auto attack loop
- Current enemy targeting
- Damage calculation flow
- Critical hit logic
- Combat events between player and enemies

Excluded:
- Enemy spawning and movement
- Loot drops
- Skills
- Prestige and economy systems
- UI polish and visual effects

## Acceptance Criteria
- [ ] Player attacks automatically at a repeatable interval based on attack speed
- [ ] Player can identify and damage a valid current target
- [ ] Damage is calculated from base stats and equipment modifiers
- [ ] Critical hits can trigger and apply bonus damage correctly
- [ ] Enemies receive damage through a consistent combat flow
- [ ] Enemy death can trigger a follow-up event for later systems

## Included Issues
- [ ] #1
- [ ] #2
- [ ] #3
- [ ] #4