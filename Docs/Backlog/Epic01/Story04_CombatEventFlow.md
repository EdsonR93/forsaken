## Description
Connect the player combat system to enemy health and death handling so combat results can be consumed by later systems such as loot and progression.

## Tasks (optional)
- [ ] Define combat event interface
- [ ] Connect combat system to enemy health
- [ ] Add death trigger event
- [ ] Expose combat debug logs

## Acceptance Criteria
- [ ] Enemy health can receive and process incoming damage
- [ ] Enemy death is triggered when health reaches zero
- [ ] A death event or callback exists for future systems
- [ ] Combat actions can be debugged during development