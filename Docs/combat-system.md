# Combat System

## Purpose

The combat system controls how the player attacks enemies, how damage is calculated, and how combat events are triggered.

This system is the foundation of the gameplay loop and must be kept simple, reusable, and easy to expand.

---

## Current Scope

The first version of the combat system includes:

- Player auto attack on a timer
- Single target attack resolution
- Damage calculation
- Critical hit support
- Enemy health reduction
- Enemy death trigger
- Combat event flow

The first version does not include:

- Multi target attacks
- Skill effects
- Status effects
- Damage over time
- Knockback
- Friendly units
- Multiple lanes

---

## Combat Loop

The first combat loop works like this:

1. Enemy exists in the scene
2. Player finds a valid target
3. Player attack timer reaches zero
4. Player attacks target
5. Damage is calculated
6. Enemy health is reduced
7. If enemy health is zero, death event is triggered

---

## System Responsibilities

### Player Combat
Responsible for:
- tracking attack timer
- finding a valid target
- triggering attacks

### Damage Calculation
Responsible for:
- base attack value
- equipment modifiers
- crit chance
- crit multiplier
- final damage output

### Enemy Health
Responsible for:
- current health
- receiving damage
- checking death
- triggering death event

### Combat Events
Responsible for:
- communicating attack happened
- communicating hit happened
- communicating death happened

---

## First Version Architecture

### Main Classes

#### PlayerCombat
Purpose:
Controls automatic player attacks.

Likely fields:
- attackInterval
- attackTimer
- currentTarget

Likely methods:
- Update
- TickAttackTimer
- FindTarget
- TryAttack
- AttackTarget

#### DamageCalculator
Purpose:
Returns final damage dealt by an attack.

Likely methods:
- CalculateDamage
- RollCriticalHit

#### EnemyHealth
Purpose:
Tracks enemy HP and processes incoming damage.

Likely fields:
- maxHealth
- currentHealth

Likely methods:
- TakeDamage
- Die
- IsDead

#### CombatEvents
Purpose:
Central place for combat notifications.

Possible events:
- OnAttack
- OnHit
- OnDeath

---

## Suggested Data Flow

PlayerCombat
-> asks for current target
-> calls DamageCalculator
-> sends result to EnemyHealth
-> EnemyHealth updates HP
-> EnemyHealth triggers death if needed
-> CombatEvents notifies other systems

---

## Targeting Rules for First Version

The first version uses simple targeting.

Rules:
- target the nearest alive enemy
- ignore dead enemies
- if no enemy exists, do nothing
- no range checks for the first version unless needed for scene setup

This keeps the system simple for the prototype.

---

## Damage Rules for First Version

The first version uses this formula structure:

FinalDamage = BaseAttack + EquipmentBonus

If crit succeeds:

FinalDamage = FinalDamage * CritMultiplier

Notes:
- keep formulas simple at first
- add more scaling later only when needed
- avoid overengineering early combat math

---

## Critical Hit Rules

The first version includes basic crit support.

Inputs:
- critChance
- critMultiplier

Behavior:
- roll random chance on attack
- if crit succeeds, multiply final damage
- expose crit result for future UI or VFX

---

## Enemy Death Rules

When enemy health reaches zero:

- stop enemy movement
- prevent further damage processing
- trigger death event
- allow future loot logic to subscribe later

The first version should avoid destroying the enemy immediately if debugging is needed.

---

## Future Expansion

Later versions may include:

- skill damage
- area attacks
- status effects
- damage over time
- attack animations
- attack windup
- multiple lanes
- boss specific combat rules

These are intentionally excluded from the first version.

---

## Testing Goals

The combat system is considered functional when:

- player attacks automatically on a timer
- enemy takes damage correctly
- crits can happen
- enemy dies when health reaches zero
- death event can be reused by later systems

---

## Implementation Notes

Keep the first implementation small.

Recommended implementation order:
1. Player auto attack
2. Damage calculation
3. Enemy health
4. Combat event flow

Do not add:
- skills
- loot
- UI feedback
- advanced targeting

until the base loop is stable.