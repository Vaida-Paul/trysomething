<div align="center">
  <img src="https://res.cloudinary.com/dxy7irilx/image/upload/v1776375873/LogoClodinary_ucwnez.png" width="120" alt="Echo Logo"/>
  <h1>Echo – Real‑time Chat & Video Call App</h1>
  <p><strong>Instant messaging • HD video calls • PWA • 12 themes • 10+ fonts</strong></p>
  <p>
    <a href="https://echo-chat-application-proj.netlify.app/"><img src="https://img.shields.io/badge/Live_Demo-echo_chat-7c6af7?style=for-the-badge&logo=netlify&logoColor=white" alt="Live Demo"/></a>
    <a href="https://github.com/Vaida-Paul/chat-app"><img src="https://img.shields.io/github/stars/Vaida-Paul/chat-app?style=for-the-badge&color=ffb86b" alt="GitHub stars"/></a>
    <a href="https://github.com/Vaida-Paul/chat-app/blob/main/LICENSE"><img src="https://img.shields.io/github/license/Vaida-Paul/chat-app?style=for-the-badge&color=50fa7b" alt="License"/></a>
  </p>
  <p>
    <img src="https://img.shields.io/badge/React-20232A?style=flat-square&logo=react&logoColor=61DAFB"/>
    <img src="https://img.shields.io/badge/TypeScript-007ACC?style=flat-square&logo=typescript&logoColor=white"/>
    <img src="https://img.shields.io/badge/Spring_Boot-6DB33F?style=flat-square&logo=spring-boot&logoColor=white"/>
    <img src="https://img.shields.io/badge/WebRTC-333333?style=flat-square&logo=webrtc&logoColor=white"/>
    <img src="https://img.shields.io/badge/PostgreSQL-4169E1?style=flat-square&logo=postgresql&logoColor=white"/>
  </p>
</div>

---

## ✨ About Echo

**Echo** is a full‑stack real‑time communication platform that combines modern messaging with high‑quality video calls. It's built as a **Progressive Web App (PWA)**, so you can install it on your phone or desktop and use it like a native app.

The goal was to create a seamless, beautiful, and fast experience – from typing indicators and read receipts to crystal‑clear WebRTC calls with screen sharing.

📱 **Live demo:** [https://echo-chat-application-proj.netlify.app/](https://echo-chat-application-proj.netlify.app/)

---

## 🎯 Key Features

| Category | Features |
|----------|----------|
| **Messaging** | Real‑time text, typing indicators, online presence, read & delivery receipts, delete for everyone, image sharing |
| **Calls** | HD video/audio calls, screen sharing, picture‑in‑picture mode, mute/unmute, toggle camera |
| **Personalisation** | 12 beautiful themes (Midnight, Galaxy, Arctic, Ember…), 10+ custom fonts (Quicksand, Pacifico, Orbitron…), profile picture upload |
| **Security** | JWT authentication, email verification, password reset, block users |
| **PWA** | Installable on any device, works offline (cached assets), push notifications |
| **Tech** | WebSockets (STOMP) for real‑time events, WebRTC for peer‑to‑peer media |

---

## 🛠️ Tech Stack

### Frontend
- **React 18** + **TypeScript** – type‑safe UI
- **Vite** – fast builds and HMR
- **Zustand** – minimal state management
- **SCSS Modules** – scoped styling
- **WebRTC** – peer‑to‑peer audio/video
- **STOMP over WebSocket** – real‑time messaging
- **Cloudinary** – image uploads
- **PWA** (vite-plugin-pwa) – installable & offline caching

### Backend
- **Spring Boot 3** – Java backend
- **Spring Security + JWT** – authentication & authorisation
- **Spring Data JPA** – database access
- **WebSocket (STOMP)** – bi‑directional communication
- **Cloudinary SDK** – file storage
- **JavaMail** – email verification & password reset

### Database & Deployment
- **PostgreSQL** (Neon) – cloud database
- **Netlify** – frontend hosting (auto‑deploy from GitHub)
- **Render** – backend hosting (Docker container)

---

## 🚀 Getting Started (Local Development)

### Prerequisites
- Node.js 18+
- Java 17+
- PostgreSQL (or a Neon cloud account)

### 1. Clone the repository
```bash
git clone https://github.com/Vaida-Paul/chat-app.git
cd chat-app
