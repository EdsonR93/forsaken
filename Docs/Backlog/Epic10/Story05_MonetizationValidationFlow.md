## Description
Validate monetization actions so purchases and ad rewards only change player state after the external action succeeds correctly.

## Tasks (optional)
- [ ] Define monetization result checks
- [ ] Block rewards on failed actions
- [ ] Apply rewards on confirmed success
- [ ] Expose validation results for debugging

## Acceptance Criteria
- [ ] Ads and purchases validate success before granting rewards
- [ ] Failed actions do not change player state incorrectly
- [ ] Successful actions grant the intended result safely
- [ ] Validation behavior can be tested during development