
# Client Engineer Examination: Unity Physics
> Created By Mohd Naim Shah

## Task 2: MLRS vs CIWS (Implementation)

1.  **Scene Setup:**
    
    -   Setup 3D tank battle scene using UnityTankTutorial template (only import some of the necessary materials)
        
    -   Blue Tank (Player 1) & Red Tank (Player 2)
      
        - Input Description included
  
    -   Project Settings:
    
        -   Multiple axis controller to accomodate P1 vs P2 interaction
        -   URP lighting setup
        -   Created object layers to control OnTrigger interactions between different game object
        -   Object layers critical for Homing Missile, Anti Missile Shell, Effective Range and Turret Auto Tracking behavior
  
    -   Folder Managements:
    
        -   Modified & built from scratch codes and prefabs placed inside "Asset/Engineer Exam" folder
        
    
2.  **Game Logics & Features:**
    
    -   Added initial missile launch animation to give it some attitude and character
      
        - Missile move along a bezier curve for a few seconds before propelled toward target
        
    -   Auto Tracking Turret
      
        - Begin AutoTrack in effective range (Refer "Turret" gameobject in each tank child game object to find the script used)
  
    -   Multiple Shell Types Prefabs:
    
        -   Missile: Homing missile, target only enemy tank (P2), turning speed and velocity can be adjusted
        -   Anti Missile: Fast moving shell only affect Missile (filter using object layer)
        -   CompleteShell (original from template asset): Basically a canon
  
------------------------------------------

This examination assesses your fundamental Unity development abilities and your capability to replicate physics scenarios.

## Task 3: MLRS vs CIWS

1.  **Introduction:**

    - A multiple launch rocket system (MLRS) is a type of rocket artillery system that contains multiple launchers which are fixed to a single platform, and shoots its rocket ordnance in a fashion similar to a volley gun. [Wiki](https://en.wikipedia.org/wiki/Multiple_rocket_launcher)
    - A close-in weapon system (CIWS) is a point-defense weapon system for detecting and destroying short-range incoming missiles which have penetrated the outer defenses. [Wiki](https://en.wikipedia.org/wiki/Close-in_weapon_system)


2.  **Unity Scene Setup:**

    - Create either a 2D or 3D Unity scene to simulate a battle between two tanks, where one tank utilizes MLRS while the other is equipped with CIWS. In this scenario, the MLRS tank will be attacking while the CIWS tank will be defending.


3.  **Implementation Details:**

    - Write a script to control how both tanks move sideways while facing each other in battle.
    
    - Implement the MLRS system for the attacking tank with these features:
      
      - Fire missiles aimed at the defending tank.
      - Missiles automatically track and lock onto their target using homing capabilities.
      - Missiles moves at a standard speed.
    
    - Implement the CIWS system for the defending tank with these features:
      
      - Detect incoming enemy homing missiles.
      - Shoot projectiles directly at enemy homing missiles to neutralize them.
      - Projectiles moves at high speed in a straight line.


4.  **Reference Images:**

|                    |
| ------------------ |
| ![A](./gifs/3.gif) |


## Extension Task (Bonus)

-   **Control Panel**

    -   Create a UI to manage the simulation parameters allowing adjustment of the tanks' speed, homing missile speed, homing missile angle, and projectile speed.

-   **Effects**

    -   Please include simple effects to make the simulation look better visually.
    

## Evaluation Criteria

-   **Functionality:** The core task requirements are met, and the scene demonstrates accurate physics simulation.
-   **Code Quality:** Code is well-organized, readable, and includes meaningful comments where necessary.
-   **Visual:** Accurately depict physics behavior to simulate realistic combat scenarios.
-   **Unity Proficiency:** Exhibits good use of Unity components, UI systems, and general Unity workflows.
