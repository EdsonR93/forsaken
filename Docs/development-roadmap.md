# Forsaken — Development Roadmap

## Overview

This document defines the recommended development order for the Forsaken project.

The backlog (Epics and Stories) is organized by system, but implementation follows a **non-blocking, phase-based approach** to ensure continuous progress and early playable builds.

The goal is to always maintain a working version of the game while incrementally adding systems.

---

## Core Principle

Build the smallest playable loop first:

Player auto attacks → Enemy takes damage → Enemy dies → Loot drops → Player upgrades

---

## Phase 1 — Core Combat Foundation

### Goal
Create a fully playable combat loop.

### Systems Involved
- Player Auto Attack System
- Enemy Spawn System
- Enemy Movement
- Damage Calculation
- Enemy Health System
- Combat Event Flow

### Implementation Order
1. PlayerAutoAttackSystem
2. EnemySpawnSystem
3. EnemyMovement
4. DamageCalculation
5. EnemyHealthSystem
6. CombatEventFlow

### Outcome
A working prototype where:
- Enemies spawn and move
- Player automatically attacks
- Enemies take damage and die

---

## Phase 2 — Loot System

### Goal
Introduce rewards and progression.

### Systems Involved
- Loot Table Setup
- Enemy Drop Flow
- Item Rarity Selection
- Boss Drop Rules
- Merge System

### Implementation Order
1. LootTableSetup
2. EnemyDropFlow
3. ItemRaritySelection
4. BossDropRules
5. MergeSystem

### Outcome
- Enemies drop loot
- Items have rarity
- Players can upgrade items

---

## Phase 3 — Equipment System

### Goal
Allow players to use and benefit from items.

### Systems Involved
- Equipment Slots
- Equip Item Flow
- Equipment Stats
- Legendary Effects
- Equipment Persistence

### Outcome
- Players equip items
- Stats affect combat

---

## Phase 4 — Skills System

### Goal
Introduce active and passive abilities.

### Systems Involved
- Skill Activation System
- Skill Cooldown System
- Skill Damage Scaling
- Auto Skill Option

### Outcome
- Players can use abilities in combat

---

## Phase 5 — Economy & Upgrades

### Goal
Add long-term progression through currency.

### Systems Involved
- Gold Reward System
- Upgrade Cost Scaling
- Player Upgrade Stats
- Upgrade UI Integration

### Outcome
- Players earn currency and upgrade power

---

## Phase 6 — Prestige System

### Goal
Enable long-term replayability through resets.

### Systems Involved
- Soft Reset System
- Permanent Upgrades
- Prestige Scaling

### Outcome
- Players reset progress for bonuses

---

## Phase 7 — Save & Offline System

### Goal
Persist player progress.

### Systems Involved
- Save System
- Load System
- Offline Progress

### Outcome
- Game saves and progresses while offline

---

## Phase 8 — UI & Player Experience

### Goal
Improve usability and feedback.

### Systems Involved
- Core Combat HUD
- Upgrade and Currency UI
- Equipment and Skills UI
- Feedback and Status
- Navigation and Menus

### Outcome
- Clear and intuitive player experience

---

## Phase 9 — Ads & Monetization

### Goal
Introduce revenue systems.

### Systems Involved
- Rewarded Ads
- In-App Purchases
- Ad Cooldown System

### Outcome
- Game generates revenue

---

## Final Notes

- Phases are designed to be **non-blocking**
- Systems may be implemented incrementally
- Always prioritize keeping the game in a **playable state**
- Avoid over-engineering early systems

---

## Development Strategy

1. Build → Test → Iterate
2. Keep features minimal at first
3. Expand systems after validation
4. Prioritize gameplay over polish

---

## Milestone Definition

A phase is considered complete when:
- Its systems are functional
- The gameplay loop is stable
- No critical blockers remain

---