## Description
Validate save state input so missing, corrupt, or outdated data does not break the game during load or offline reward processing.

## Tasks (optional)
- [ ] Check required save fields
- [ ] Handle missing or invalid values
- [ ] Add fallback initialization logic
- [ ] Expose validation results for debugging

## Acceptance Criteria
- [ ] Invalid or incomplete save data is handled safely
- [ ] Missing values can fall back to valid defaults when possible
- [ ] Load failures do not leave the game in a broken state
- [ ] Validation behavior can be tested during development