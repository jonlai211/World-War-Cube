#### Game Specification: World War Cube

[![Bilibili](https://img.shields.io/badge/Bilibili-%E6%92%AD%E6%94%BE%E5%9C%B0%E5%9D%80-red)](https://www.bilibili.com/video/BV1Sx4y1n7TA)

#### 1. Overview

**Title:** World War Cube  
**Genre:** Action, Strategy  
**Platform:** Windows
**Target Audience:** Teens and Adults

**Description:**
World War Cube is an action-packed strategy game where players control a hero cube and battle against a formidable boss cube. The game involves moving, attacking, and using various skills to defeat the boss while collecting skill coins to power up. Players must strategically use their skills to overcome obstacles and defeat the boss.

#### 2. Game Mechanics

**Hero Movement:**
- **Right Click:** Move to the indicated place.
- **Left Click:** Shoot towards the boss.

**Skill Levels and Controls:**
- **Press Alpha1 to Alpha5:** Select skills from level 1 to level 5.
  - **Level 1:** Basic Straight Shoot
  - **Level 2:** Parabolic Attack
  - **Level 3:** Area Of Effect (AOE) Attack (requires skill coins)
  - **Level 4:** Attach Attack (brings additional stick damage)
  - **Level 5:** Elemental Attack (inflicts burning damage over time)

**Camera Control:**
- **Press Q:** Rotate the camera clockwise.
- **Press E:** Rotate the camera counterclockwise.

**Skill Coin Collection:**
- **Skill Coins:** Collect skill coins to use Level 3 AOE skill.
- **Maximum Coins:** Up to 3 skill coins can appear in the game, one at a time.

#### 3. Game Entities

**Hero:**
- **Size:** 1x1x1 units
- **Health:** Displayed on UI
- **Skills:** Various levels of attacks as described above

**Boss:**
- **Size:** 4x4x4 units
- **Health:** Displayed on UI
- **Skills:** Randomly uses one of the skills (except AOE)

**Obstacles:**
- **Count:** 20 obstacles
- **Size:** 1x1x1 units (height varies: some 2 units high, others 1 unit high)
- **Placement:** Random positions, ensuring no overlap with the boss or each other

**Skill Coins:**
- **Size:** 0.5x0.5 units
- **Function:** Allows usage of AOE skill when collected by the hero

#### 4. Game Flow

1. **Start Game:** Player clicks "Start Game" to begin.
2. **Gameplay:**
   - Player navigates the hero cube and battles the boss cube.
   - Player collects skill coins to enable powerful AOE attacks.
   - Player uses strategic skills to inflict damage and avoid obstacles.
3. **Victory Condition:** The boss cube's health is reduced to zero.
4. **Defeat Condition:** The hero cube's health is reduced to zero.
5. **End Game:**
   - Display "Victory" and total elapsed time if the player defeats the boss.
   - Display "Lost" if the hero cube dies.
   - Show "Exit" and "Restart" buttons.
   - Transition to End Scene showing the result and elapsed time.

#### 5. User Interface

**Main Menu:**
- **Start Game:** Begin the game.
- **Guide:** Show instructions for playing the game.
- **Exit:** Close the game.

**In-Game UI:**
- **Health Display:** Shows current health of hero and boss.
- **Skill Level Display:** Shows the currently selected skill level.
- **Skill Coin Display:** Shows the number of skill coins collected.
- **Timer:** Displays elapsed game time.

**Guide Screen:**
- **Instructions:**
  - Enter "Start Game"
  - Right click to move to indicated place
  - Left click to shoot towards the boss
  - Press Alpha1 to Alpha5 to select skills from level 1 to level 5
  - Press Q and E to rotate the camera
  - Collect Skill Coin to execute Level 3 skill (AOE)
  - Skill Details:
    - Level 1: Basic Straight Shoot
    - Level 2: Parabolic Attack
    - Level 3: Area Of Effect Attack (requires skill coins)
    - Level 4: Attach Attack (additional stick damage)
    - Level 5: Elemental Attack (burning damage over time)

**End Scene:**
- **Result:** Display "Victory" or "Lost" based on the game outcome.
- **Elapsed Time:** Display the total time taken in the game.
- **Buttons:** "Exit" and "Restart" options.

#### 6. Audio

**Background Music:**
- Continuous, looping background music ”The Last of Us“ that plays throughout all scenes.
- Music should not restart when transitioning between scenes.
