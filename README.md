# 🎓 Student Management System — ASP.NET Core Web API

A fully functional Student Management REST API built with ASP.NET Core, Entity Framework Core, JWT Authentication, Serilog Logging, and Swagger UI.

---

## 🏢 Project Info

- **Company:** Zest India IT Services
- **Role:** .NET Developer
- **Organized By:** ADVANTO, Pune
- **Candidate:** Pawar Sushant Hanmant
- **Email:** sushantpawar1232@gmail.com

---

## 🚀 Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server (SQLEXPRESS)
- JWT Authentication
- Serilog (Console + File Logging)
- Swagger UI (with JWT Support)
- Layered Architecture (Controller → Service → Repository)

---

## 📁 Project Structure

```
StudentManagementSystem/
├── Auth/
│   └── JwtHelper.cs
├── Controllers/
│   ├── AuthController.cs
│   └── StudentsController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Middleware/
│   └── ExceptionMiddleware.cs
├── Migrations/
├── Models/
│   ├── Student.cs
│   └── StudentDTO.cs
├── Repository/
│   ├── IStudentRepository.cs
│   └── StudentRepository.cs
├── Services/
│   ├── IStudentService.cs
│   └── StudentService.cs
├── Logs/
│   └── log.txt (auto-generated)
├── appsettings.json
└── Program.cs
```

---

## ⚙️ Setup Instructions

### Step 1: Clone Repository
```bash
git clone https://github.com/debugwithsushant/StudentManagementSystem.git
cd StudentManagementSystem
```

### Step 2: Configure Database
Open `appsettings.json` and update connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
> Replace `localhost\\SQLEXPRESS` with your SQL Server instance name.

### Step 3: Install NuGet Packages
```bash
dotnet restore
```

Or install manually via NuGet Package Manager:
```
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.AspNetCore.Authentication.JwtBearer
Serilog.AspNetCore
Serilog.Sinks.Console
Serilog.Sinks.File
```

### Step 4: Apply Migrations
Open **Package Manager Console** and run:
```
Add-Migration InitialCreate
Update-Database
```
This will create `StudentDB` database and `Students` table automatically.

### Step 5: Run the Project
```bash
dotnet run
```
Or press **F5** in Visual Studio.

### Step 6: Open Swagger UI
```
https://localhost:7260/swagger
```

---

## 🔐 JWT Authentication

### Login to get Token
**POST** `/api/auth/login`
```json
{
  "username": "admin",
  "password": "admin123"
}
```

### Response
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Authorize in Swagger
1. Click **Authorize 🔓** button in Swagger UI
2. Enter token in this format:
```
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```
3. Click **Authorize** → **Close**
4. All secured endpoints are now accessible ✅

---

## 📌 API Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/api/auth/login` | Get JWT Token | ❌ |
| GET | `/api/students` | Get all students | ✅ |
| GET | `/api/students/{id}` | Get student by ID | ✅ |
| POST | `/api/students` | Add new student | ✅ |
| PUT | `/api/students/{id}` | Update student | ✅ |
| DELETE | `/api/students/{id}` | Delete student | ✅ |

---

## 📝 Request & Response Examples

### GET /api/students
```json
[
  {
    "id": 1,
    "name": "Ram",
    "email": "ram@gmail.com",
    "age": 20,
    "course": "BCA",
    "createdDate": "2026-04-10T13:18:26.45"
  }
]
```

### POST /api/students
**Request:**
```json
{
  "name": "Shyam",
  "email": "shyam@gmail.com",
  "age": 21,
  "course": "BCS"
}
```
**Response — 201 Created:**
```json
{
  "id": 2,
  "name": "Shyam",
  "email": "shyam@gmail.com",
  "age": 21,
  "course": "BCS",
  "createdDate": "2026-04-10T13:19:17.63"
}
```

### PUT /api/students/1
**Request:**
```json
{
  "name": "Sita",
  "email": "sita@gmail.com",
  "age": 25,
  "course": "B.Com"
}
```
**Response — 200 OK:**
```json
{
  "id": 1,
  "name": "Sita",
  "email": "sita@gmail.com",
  "age": 25,
  "course": "B.Com",
  "createdDate": "2026-04-10T13:18:26.45"
}
```

### DELETE /api/students/1
**Response — 200 OK:**
```
Student with ID 1 deleted successfully...!
```

---

## 🛡️ Global Exception Handling

All unhandled exceptions return structured JSON:
```json
{
  "statusCode": 500,
  "message": "An unexpected error occurred...!",
  "detail": "Exception details here"
}
```

---

## 📋 Logging

Serilog is configured for:
- **Console** — real-time logs while running
- **File** — saved in `Logs/log.txt` (daily rolling)

Log levels used:
- `LogInformation` — normal operations
- `LogWarning` — not found cases
- `LogError` — unhandled exceptions

---

## 🗄️ Database Schema

```sql
CREATE TABLE Students (
    Id          INT PRIMARY KEY IDENTITY(1,1),
    Name        NVARCHAR(MAX)  NOT NULL,
    Email       NVARCHAR(MAX)  NOT NULL,
    Age         INT            NOT NULL,
    Course      NVARCHAR(MAX)  NOT NULL,
    CreatedDate DATETIME2      NOT NULL
);
```

---

## 🏗️ Architecture

```
Request
   ↓
Controller  (handles HTTP requests)
   ↓
Service     (business logic)
   ↓
Repository  (database operations)
   ↓
DbContext   (Entity Framework Core)
   ↓
SQL Server
```

---

## 👨‍💻 Author

**Your Full Name**
- GitHub: https://github.com/debugwithsushant
- Email: sushantpawar1232@gmail.com

---

## 🏁 Conclusion

This project demonstrates a complete Student Management REST API with clean layered architecture, JWT security, global error handling, structured logging, and full Swagger documentation.