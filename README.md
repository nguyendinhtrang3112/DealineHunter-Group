# 🎓 Deadline Hunter (Săn Lùng Deadline)

> **"Chạy ngay đi trước khi thầy bắt được!"**  
> Một tựa game 2D Platformer tái hiện hành trình đầy cam go của sinh viên năm cuối trong cuộc đua hoàn thành đồ án tốt nghiệp.

---

## 📖 Giới thiệu (About)

**Deadline Hunter** đưa người chơi vào vai một sinh viên năm 4 lười biếng nhưng đang ở giai đoạn nước rút.  
Nhiệm vụ của bạn là vượt qua các cám dỗ (Game, MXH), thu thập tài liệu học tập và né tránh sự truy đuổi gắt gao của **Thầy Giáo Khó Tính** để bảo vệ đồ án ra trường.

### 🎯 Mục tiêu

- 🏃 **Chạy & Nhảy:** Vượt qua chướng ngại vật địa hình.  
- 📚 **Thu thập:** Gom đủ số lượng **Sách/Laptop** để mở khóa màn mới.  
- ❤️ **Sinh tồn:** Giữ sự tỉnh táo không về 0 khi va chạm với kẻ thù hoặc bẫy.

---

## 👥 Nhóm Thực Hiện (Team 13)
Giáo Viên Hướng dẫn: **Đinh Bảo Ngọc**

| STT | Họ và Tên            | Mã Sinh Viên  | Vai trò                        |
|:---:|----------------------|:-------------:|--------------------------------|
| 1   | **Phan Thanh Tú**    | 2221050845    | Level 2 |
| 2   | **Nguyễn Đình Tráng**| 2221050306    | Level 1         |
| 3   | **Nguyễn Đức Mạnh**  | 2221050617    | Level 3         |

---

## 🎮 Tính năng nổi bật (Key Features)

### 1. Hệ thống AI Kẻ Thù (Smart Enemy AI)

Kẻ thù (Thầy giáo) sử dụng **Finite State Machine (FSM)**, với khả năng:

- 🕵️ **Dò đường:** Phát hiện và truy đuổi người chơi trong phạm vi.  
- 🚧 **Vượt chướng ngại vật:** Raycast (`WallCheck`) giúp phát hiện tường và tự nhảy qua.  
- **States:** `Idle` ↔ `Chase` ↔ `Jump`.

### 2. Cơ chế Điều khiển Nhân vật (Smooth Player Controller)

- Hỗ trợ **Jump** và **Run Jump**.  
- Animation mượt bằng **Animator Blend Tree**.  
- Vật lý `Rigidbody2D` được tinh chỉnh để di chuyển chắc tay.

### 3. Thiết kế màn chơi (Level Progression)

- **Level 1 – Đô thị:** Né cám dỗ, làm quen gameplay.  
- **Level 2 – Trường học:** Đối đầu Thầy giáo, thu thập sách.  
- **Level 3 – Phòng Lab:** Chạy đua với thời gian, thu thập Laptop để code đồ án.

---

## 🛠️ Công nghệ sử dụng (Tech Stack)

- **Game Engine:** Unity (2D Core)  
- **Ngôn ngữ:** C#  
- **Đồ họa:** Pixel Art (Aseprite / Photoshop)  
- **IDE:** Visual Studio / VS Code  
- **Quản lý phiên bản:** Git / GitHub  

---

## 🕹️ Hướng dẫn chơi (Controls)

| Phím (PC) | Hành động |
|-----------|-----------|
| **A / D** hoặc **← / →** | Di chuyển |
| **Space** | Nhảy (Giữ để nhảy cao hơn) |
| **Esc** | Tạm dừng trò chơi |

---

## ⚙️ Cài đặt & Chạy (Installation)

1. Clone dự án về máy:
    ```bash
    git clone https://github.com/nguyendinhtrang3112/DealineHunter-Group.git
    ```
2. Mở **Unity Hub** → **Add** → Chọn thư mục dự án.  
3. Mở bằng Unity Editor (khuyến nghị: 2021.3 LTS+).  
4. Mở Scene: `Assets/Scenes/Level1.unity`.  
5. Nhấn ▶️ **Play** để chạy game.  

---

## 📝 Nhật ký phát triển (Dev Log)

- **Tuần 1:** Lên ý tưởng, thiết kế nhân vật – cốt truyện.  
- **Tuần 2:** Player Controller, Physics cơ bản.  
- **Tuần 3:** AI Enemy (Chase + Jump), xử lý `LayerMask`.  
- **Tuần 4:** UI, Score, hoàn thiện 3 màn chơi & sửa bug.  

---

**© 2025 – Nhóm 13, Đại học Mỏ Địa Chất.**


