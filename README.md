# Task Management API

A simple Task Management API built with ASP.NET Core Web API and SQL Server.  
This project demonstrates basic backend development practices including CRUD operations, filtering, sorting, validation, and layered architecture.

---

## 🚀 Features

- Create, Read, Update, Delete (CRUD) tasks
- Filter tasks by status (e.g., Todo, Doing, Done)
- Sort tasks by creation time (latest first)
- Input validation using Data Annotations
- Clean architecture with Service Layer
- API testing with Swagger UI

---

## 🧱 Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (Express)
- Swagger / OpenAPI
- Git & GitHub

---

## 📂 Project Structure


TaskApi/
├─ Controllers/ # Handle HTTP requests and responses
├─ Services/ # Business logic layer
│ ├─ Interfaces/
│ └─ TaskService.cs
├─ DTOs/ # Request / Response models
├─ Models/ # Database entities
├─ Data/ # DbContext
├─ Program.cs
└─ appsettings.json


---

## 🔧 API Endpoints

| Method | Endpoint | Description |
|-------|--------|------------|
| GET | /api/Tasks | Get all tasks (with optional status filter) |
| GET | /api/Tasks/{id} | Get task by id |
| POST | /api/Tasks | Create a new task |
| PUT | /api/Tasks/{id} | Update a task |
| DELETE | /api/Tasks/{id} | Delete a task |

---

## 🧪 Example Request (POST)

```json
{
  "title": "Prepare interview",
  "description": "Practice backend questions",
  "status": "Todo"
}
## 🧠 Design Highlights

DTO Pattern
Separates API models from database entities to reduce coupling.

Service Layer
Moves business logic out of controllers for better maintainability.

Validation
Ensures required fields and data constraints before processing.

📌 Purpose

This project was built to refresh backend development skills and practice API design, database integration, and basic system architecture.

📎 Future Improvements

Pagination for large datasets

Enum for task status

Global exception handling

Unit testing