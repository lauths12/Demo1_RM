# 🕯️ Horror Game – Mixed Reality

## Overview
This project presents the development of an **immersive horror game** set in the mysterious house of an alchemist.  
The player’s main objective is to **explore the environment** and find **three hidden keys** to complete the experience and escape.  
Throughout the game, the player must avoid a **monster** that patrols the house, generating constant tension and fear through realistic interactions and environmental design.

The project was developed as part of the **Mixed Reality Application Development** course at *Universidad de los Andes* and was showcased during the **Colivri Lab Open House**.

---

## 🎮 Technology Stack

- **Game Engine:** Unity  
- **Programming Language:** C#  
- **Hardware:** Virtuix Omni (omnidirectional treadmill) and HTC Vive Pro 2  
- **Assets:** Free assets from the Unity Asset Store  
- **Animation:** Mixamo  
- **Interaction:** HTC Vive controllers with haptic feedback  
- **Version Control:** Git / GitHub  

---

## ⚙️ Hardware Integration

### HTC Vive Pro 2
The VR headset was successfully integrated, providing full motion tracking and interaction capabilities from the beginning of the project.

### Virtuix Omni
The integration of the Virtuix Omni represented the greatest technical challenge, as the available SDKs only supported the **Omni One** model.  
This issue was solved by obtaining the required SDK, Omni Calibration, and Omni Connection tools, which allowed successful calibration and synchronization of player movement.

### Movement Synchronization
Early versions of the game linked movement to waist orientation, resulting in discomfort.  
After several adjustments, movement was synchronized with **head tracking**, achieving a much smoother and natural user experience.

---

## 🧩 Game Design and Mechanics

The final version of the game focused on creating a **stealth-based horror experience** within an **alchemist’s laboratory**.  
Players must explore the space, avoid detection, and interact with objects to survive and escape.

### Gameplay Features
- Avoid staying in the monster’s field of vision for more than a few seconds, or it will begin to chase you.  
- Hide or escape to reset the monster’s pursuit behavior.  
- Use the HTC Vive Pro controllers to:
  - Pick up keys and unlock doors.  
  - Grab or throw objects to distract the monster.  
  - Interact with candles, lights, and furniture for narrative depth.  

---

## 👾 Monster and Environment Design

The main enemy, the **Book Head Monster**, features a unique design with a book-shaped head and a central glowing eye.  
The model was animated using **Mixamo**, incorporating patrol, search, and chase behaviors.

A **dynamic light system** was implemented in the monster’s eye to indicate its detection range — if the player stays within this light for too long, the monster begins pursuit.

The environment was designed as an **alchemist’s laboratory**, filled with tables, old books, flasks, and mystical props, all illuminated with dim and atmospheric lighting to reinforce the horror theme.

---

## 🧠 Immersion and Realism Test – Qualitative Evaluation

### Hypothesis
It was hypothesized that the combination of **HTC Vive Pro 2** and **Virtuix Omni** would significantly increase player immersion and emotional response compared to traditional VR setups using only headsets and controllers.  
The goal was to evaluate how physical movement integration intensifies fear perception, realism, and overall immersion.

### Methodology
Three participants experienced the demo using the full setup (HTC Vive Pro 2 + Virtuix Omni).

### Results

- **Participant 1:** Found the experience more realistic and tense but noticed a slight mismatch between real walking speed and in-game movement, which briefly broke immersion.  
- **Participant 2:** Highlighted the natural freedom of movement, especially turning, though missed the ability to crouch, which limited realism during chase moments.  
- **Participant 3:** Experienced mild motion sickness but described a strong sense of vulnerability and presence due to physical movement in a threatening environment.

### General Observations
- The Virtuix Omni increased physical engagement, making the experience more intense.  
- Physical effort heightened psychological tension, especially during chase scenes.  
- The combination of hardware elements substantially enhanced immersion and realism.

---

## 🎥 Demonstration Video

[![Watch the video](https://img.youtube.com/vi/cmCVP-zcK-I/maxresdefault.jpg)](https://youtu.be/cmCVP-zcK-I)

> ⚠️ **Note:**  
> The video was recorded directly from Unity. Due to the game’s high resource usage, the recording appears **slower and slightly delayed** compared to the actual in-headset experience with the **HTC Vive Pro 2**, where movement is fluid and natural.

---

## 🏁 Conclusion
The project successfully achieved its objectives of **creating an immersive and realistic mixed reality horror experience**.  
Through the integration of the **Virtuix Omni** and **HTC Vive Pro 2**, the game demonstrated how combining physical motion with virtual environments can significantly enhance user presence and emotional impact.  
The result is a technically challenging and innovative project that merges **VR gameplay, physical immersion, and psychological horror** in a cohesive experience.

---

## 👩‍💻 Author
**Julieth Carretero**  
Mixed Reality Application Development – Universidad de los Andes  
[GitHub Profile](https://github.com/)

---

### 🧠 Keywords
Unity • C# • Mixed Reality • Virtuix Omni • HTC Vive Pro 2 • VR Interaction • Haptic Feedback • Game Design • AI • Immersive Experience
