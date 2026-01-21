# 🛒 E-Commerce System – Clean Architecture (.NET)

A scalable and secure **E-Commerce System** built with **ASP.NET Core**, following **Clean Architecture principles**, with full authentication, authorization, real-time communication, and test coverage.

---

## 🚀 Tech Stack

- **Backend:** ASP.NET Core Web API
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API)
- **Authentication:** ASP.NET Core Identity + JWT + Refresh Tokens
- **Authorization:** Role-Based & Permission-Based Authorization
- **Database:** Entity Framework Core
- **Real-time:** SignalR (WebSocket)
- **Client:** Blazor Server
- **Testing:** xUnit + InMemory Database
- **CI/CD:** GitHub Actions
- **Version Control:** Git & GitHub

---

## 🧱 Project Structure

EcommerceSystem
│
├── EcommerceSystem.Domain
│ ├── Entities
│ ├── Enums (Roles, Permissions)
│ └── Base Models
│
├── EcommerceSystem.Application
│ ├── DTOs
│ ├── Interfaces
│ ├── Services
│ └── Business Logic
│EcommerceSystem.Infrastructure
│ ├── Data (DbContext)
│ ├── Identity
│ ├── Repositories
│ └── Seed Data
│
├── EcommerceSystem.API
│ ├── Controllers
│ ├── Authentication & Authorization
│ ├── SignalR Hubs
│ └── Program.cs
│
└── EcommerceSystem.Tests
├── Repository Tests
├── Service Tests
└── InMemory Database Setup
---

## 🔐 Security Features

- ASP.NET Core Identity with `Guid` as primary key
- JWT Authentication with Refresh Token mechanism
- Role-Based Authorization:
  - `SuperAdmin`
  - `Admin`
  - `User`
- Permission-based access control
- Secure JWT key handling using **Environment Variables**
- Token expiration & renewal strategy

---

## 👥 Roles & Permissions

| Role        | Permissions |
|------------|-------------|
| SuperAdmin | Full system access |
| Admin      | Manage products, users, orders |
| User       | Browse products, place orders |

---

## 📦 Features

### 🛍️ Products
- Pagination
- Filtering
- Searching
- Sorting

### 💬 Real-time Chat
- SignalR WebSocket integration
- Blazor Server client
- Authenticated users only

### 🔁 Authentication
- Register
- Login
- Logout
- Refresh Token

---

## 🧪 Testing

- Unit tests using **xUnit**
- Repository pattern testing
- Separate seed data for tests
- InMemory database for fast execution
- Covers core business logic

---

