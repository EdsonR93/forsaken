## Overview
Implement the equipment system for Forsaken. This epic establishes player equipment slots, equip and unequip behavior, stat application from equipped items, and validation rules so loot can directly affect combat performance.

## Scope
Included:
- Equipment slot setup
- Equip and unequip flow
- Stat application from equipped items
- Equipment persistence model
- Validation rules for equippable items

Excluded:
- Inventory UI polish
- Named legendary unique effect behavior
- Merge logic
- Cosmetic-only equipment visuals
- Premium purchase equipment

## Acceptance Criteria
- [ ] The player has the planned equipment slots available
- [ ] Items can be equipped into valid slots
- [ ] Equipped items modify player stats correctly
- [ ] Invalid equipment actions are blocked safely
- [ ] Equipped item state can be saved and restored
- [ ] The equipment system is reusable and easy to extend later

## Included Issues
- [ ] #19
- [ ] #20
- [ ] #21
- [ ] #22
- [ ] #23