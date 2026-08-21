# Student Portal – ASP.NET MVC Application

## 📌 Project Overview

Student Portal is an ASP.NET Core MVC web application developed as a learning and practical project to understand the complete software development lifecycle.

The project demonstrates:

- ASP.NET Core MVC architecture
- Entity Framework Core
- SQL Server database integration
- CRUD operations
- Git and GitHub source control
- GitHub Issues/Tickets for activity tracking
- Branch-based development workflow
- IIS deployment
- Development environment hosting

The project will be developed incrementally using Sprint and Ticket-based activities.

---

## 🎯 Project Objectives

The main objectives of this project are:

1. Build an ASP.NET MVC web application from scratch.
2. Implement CRUD operations using Entity Framework Core.
3. Work with multiple related database entities.
4. Follow a proper Git/GitHub branching strategy.
5. Track development activities using GitHub Issues.
6. Deploy the application on IIS.
7. Maintain a Development branch for the IIS-hosted application.
8. Follow a Sprint-based development process.
9. Learn the complete development → testing → deployment workflow.

---

## 🛠️ Technology Stack

### Backend

- C#
- ASP.NET Core MVC
- Entity Framework Core
- LINQ
- ADO.NET (if required)
- .NET

### Frontend

- HTML5
- CSS3
- Bootstrap
- JavaScript
- jQuery
- AJAX

### Database

- Microsoft SQL Server
- Entity Framework Core
- SQL Server Management Studio (SSMS)

### Development Tools

- Visual Studio
- Git
- GitHub
- GitHub Issues
- GitHub Projects

### Deployment

- IIS (Internet Information Services)
- Windows Server / Windows IIS

---

# 🏗️ Project Modules

The application will contain multiple modules.

## 1. Department Management

CRUD operations for departments.

### Operations

- Create Department
- View Department
- Update Department
- Delete Department
- Search Department

---

## 2. Course Management

CRUD operations for courses.

### Operations

- Create Course
- View Course
- Update Course
- Delete Course
- Search Course

Courses will be associated with the appropriate Department.

---

## 3. Student Management

CRUD operations for students.

### Operations

- Create Student
- View Student
- Update Student
- Delete Student
- Search Student

Students will be associated with the appropriate Course/Department.

---

# 🗄️ Database Structure

The application will use SQL Server as the database.

Planned tables:

```text
Department
    |
    |----< Course
              |
              |----< Student
