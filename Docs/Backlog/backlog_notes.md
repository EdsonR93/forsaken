# Backlog Notes

This file documents the workflow used to plan, generate, and manage the Forsaken backlog in GitHub.

## Repository Scope

This repository contains game development planning and workflow assets only.

Included:
- Docs/Backlog
- Scripts/gh
- .github templates
- Unity project files

Excluded:
- Business planning documents
- Studio level financial or SEAP documents

Business and studio documentation is stored in the separate Night Wonder documentation repository.

## Backlog Structure

The backlog is organized by Epic folders.

Example:

Docs/Backlog/Epic01/
- Epic01_CoreCombat.md
- Story01_PlayerAutoAttack.md
- Story02_DamageCalculation.md

Each Epic folder contains:
- one Epic markdown file
- one markdown file per Story in that Epic

## Issue Templates

GitHub issue templates are stored in:

.github/ISSUE_TEMPLATE

Current templates:
- epic.yml
- story.yml
- bug.yml
- chore.yml

Pull request template:
- .github/PULL_REQUEST_TEMPLATE.md

## Label Workflow

Labels are created with:

Scripts/gh/create-labels.ps1

Current base labels:
- epic
- story
- bug
- chore
- gameplay
- ui
- economy
- technical

Label cleanup may happen after issue creation if a Story fits better under ui, economy, or technical.

## Epic File Generation Workflow

Epic folders and empty markdown files are generated with:

Scripts/gh/create-epic-structure.ps1

The script creates:
- Epic folder
- Epic markdown file
- Story markdown files
- create-issues.ps1 content for the current Epic only

Important:
The script should overwrite create-issues.ps1 for the current Epic, not append to it.

Reason:
The workflow creates and uploads one Epic at a time so GitHub issue numbers can be captured and inserted back into the Epic file.

## Issue Creation Workflow

1. Run create-epic-structure.ps1 for the target Epic.
2. Paste content into the generated Epic and Story files.
3. Run Scripts/gh/create-issues.ps1.
4. Capture the GitHub issue numbers created for the Epic and Stories.
5. Update the Epic markdown file Included Issues section with real issue references.
6. Run gh issue edit on the Epic to update its body with the final linked story numbers.
7. Adjust labels if needed.

## Included Issues Format

Epic markdown files should use GitHub checklist syntax.

Example:

- [ ] #12
- [ ] #13
- [ ] #14

Important:
There must be a space inside the checkbox syntax for GitHub to render it correctly.

Correct:
- [ ] #12

Incorrect:
- [] #12

## Current Epic Plan

1. Core Combat System
2. Enemy System
3. Loot System
4. Equipment System
5. Skills System
6. Economy and Upgrades
7. Prestige System
8. Save and Offline System
9. UI and Player Experience
10. Ads and Monetization

## Recommended Implementation Order

Recommended dependency aware development order:

1. Core Combat System
2. Enemy System
3. Economy and Upgrades
4. Loot System
5. Equipment System
6. Skills System
7. Prestige System
8. Save and Offline System
9. UI and Player Experience
10. Ads and Monetization

This order favors early playable progress and system dependencies.

## Branch Strategy

Main branches:
- main for stable code
- dev for integration

Feature branch naming:
- feature/story-1-1-player-auto-attack
- feature/story-2-2-enemy-spawn-system
- feature/story-6-2-gold-reward-flow

Bugfix branch naming:
- fix/save-load-bug
- fix/crit-calculation

## Story Execution Guidance

Work story by story.

Recommended first implementation path:
- Story 1.1 Player Auto Attack System
- Story 2.2 Enemy Spawn System
- Story 2.3 Enemy Movement
- Story 1.2 Damage Calculation
- Story 1.3 Critical Hit System
- Story 1.4 Combat Event Flow

This creates a visible playable loop early.

## GitHub CLI Notes

Create labels:
- Scripts/gh/create-labels.ps1

Create current Epic issues:
- Scripts/gh/create-issues.ps1

Typical Epic update command:
gh issue edit EPIC_NUMBER --body-file .\Docs\Backlog\EpicXX\EpicXX_Name.md

Typical label update command:
gh issue edit ISSUE_NUMBER --remove-label gameplay --add-label ui

## Maintenance Notes

- Keep Epic and Story markdown files as the source of truth.
- Use GitHub issues as the execution layer.
- Update Epic Included Issues after Story issue numbers are known.
- Keep labels simple during creation and refine later if needed.
- Avoid long separator lines or unusual special characters in markdown used for CLI upload.