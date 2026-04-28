## Description
Add validation rules so only correct item types can be equipped into each slot and invalid equipment actions are rejected safely.

## Tasks (optional)
- [ ] Validate slot and item type match
- [ ] Reject invalid equip attempts
- [ ] Prevent null or broken slot updates
- [ ] Expose validation results for debugging

## Acceptance Criteria
- [ ] Items can only be equipped into valid matching slots
- [ ] Invalid equip attempts do not break player state
- [ ] Slot updates remain consistent after failed actions
- [ ] Validation behavior can be tested during development