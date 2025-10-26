# 🕯️ Horror Game – Mixed Reality

## Overview
This project consists of the development of an **immersive horror game** set inside the mysterious house of an alchemist.  
The player must explore the environment in search of **three hidden keys** to complete the experience and escape. However, the task becomes challenging due to the **constant presence of a monster** patrolling the house, generating continuous tension and fear throughout the gameplay.

The game was developed as part of the **Mixed Reality Application Development** course at *Universidad de los Andes* and showcased during the **Colivri Lab Open House**.

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
The VR headset was integrated successfully, allowing full detection and tracking from the start of development.

### Virtuix Omni
Integrating the Virtuix Omni presented the main technical challenge, as the available SDK documentation only supported the **Omni One** model.  
To solve this, support files (SDK, Omni Calibration, and Omni Connection) were obtained from a student who had previously taken the course, enabling full calibration and synchronization.

### Movement Synchronization
Initially, movement was unnatural because the direction depended on waist orientation instead of head tracking. After several adjustments, player movement was synchronized with **gaze direction**, providing a smoother and more natural experience.

---

## 🧩 Game Design and Mechanics

The original concept envisioned a **dark hospital** environment, but this was reworked due to motion sickness and limited visibility.  
The new design focuses on a **stealth-based horror experience** in an alchemist’s laboratory, with improved lighting and optimized navigation.

### Gameplay Features
- Avoid being within the monster’s field of vision for more than 5–10 seconds, or it will begin to chase you.  
- Hide to escape the monster’s pursuit and reset its search state.  
- Interact physically with objects using the HTC Vive controllers:
  - Pick up keys to unlock doors.  
  - Grab and throw objects to distract the monster.  
  - Manipulate candles, lights, and furniture in the environment.  

---

## 👾 Monster Design and Future Implementation

- **Model:** *Book Head Monster* — featuring a book-shaped head with a central eye.  
- **Animations:** Implemented using **Mixamo**, including patrol, search, and chase cycles.  
- **Eye Light System:** The monster’s eye emits a flashlight-style beam that defines its detection range.  
  - If the player stays within the beam for too long, the monster initiates a pursuit.  
- **Environment Update:** The final scene will include alchemist-style elements — experimental tables, ancient books, mystical jars, and dim lighting to match the game’s narrative.

---

## 🧠 Immersion and Realism Test – Qualitative Evaluation

### Hypothesis
The hypothesis was that combining the **HTC Vive Pro 2** with the **Virtuix Omni** significantly increases the player’s **immersion and emotional response** compared to a traditional VR experience using only headsets and controllers.  
The goal was to analyze how integrating physical motion into a horror environment affects fear perception, realism, and immersion levels.

### Methodology
The test involved three participants who played the demo using both the HTC Vive Pro 2 and the Virtuix Omni.

### Results

- **Participant 1:** Reported higher realism and tension, though noticed a mismatch between walking speed and in-game movement, which slightly reduced immersion.  
- **Participant 2:** Appreciated the ability to turn naturally, which enhanced presence, but noted a lack of flexibility for crouching or body movements during danger moments.  
- **Participant 3:** Experienced motion sickness but described a unique sense of vulnerability from moving physically in a hostile environment.

### General Observations
- The Virtuix Omni increased physical engagement and intensity compared to controller-only experiences.  
- Physical effort amplified psychological tension during chase sequences.  
- Immersion was strongly influenced by technical calibration between physical and virtual motion.

---

## 🚀 Future Work

- Design and texture the final alchemist-themed environment.  
- Integrate the Book Head Monster model and animations.  
- Implement dynamic lighting and AI for patrol and chase states.  
- Optimize performance to minimize motion sickness and latency.  
- Enhance synchronization between Virtuix Omni and VR tracking systems.

---

## 🎥 Demonstration Video
**Final Gameplay Video:** [Watch on YouTube](https://youtu.be/cmCVP-zcK-I)

> ⚠️ **Note:**  
> The recording was captured directly from the Unity editor.  
> Due to the game’s high performance requirements, the screen recording shows **delay and reduced frame rate** compared to the actual experience through the **HTC Vive Pro 2**, where movement is smooth and immersive.

---

## 👩‍💻 Author
**Julieth Carretero**  
Mixed Reality Application Development – Universidad de los Andes  
[GitHub Profile](https://github.com/)  

---

### 🧠 Keywords
Unity • C# • Mixed Reality • Virtuix Omni • HTC Vive Pro 2 • VR Interaction • Haptic Feedback • Game Design • AI • Immersive Experience
