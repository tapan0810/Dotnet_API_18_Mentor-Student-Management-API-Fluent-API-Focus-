📘 Mentor–Student Management API

A .NET Web API demonstrating Fluent API & Navigation Properties in EF Core

🚀 Overview

This project is an ASP.NET Core Web API built to demonstrate a clean and scalable implementation of Entity Framework Core Fluent API with properly configured navigation properties.

The system models a real-world relational structure where:

A Mentor can guide multiple Students

Each Student is assigned to exactly one Mentor

The primary focus of this project is mastering:

One-to-Many relationships

Fluent API configuration

Navigation property handling

Foreign key constraints

Cascade delete behavior

Clean database migrations

🏗 System Design
Relationship Model
Mentor (1) -------- (Many) Students

Mentor contains a collection of Students

Student contains a reference to its Mentor

📂 Project Structure
MentorStudentAPI/
│
├── Controllers/
│     ├── MentorController.cs
│     └── StudentController.cs
│
├── Models/
│     ├── Mentor.cs
│     └── Student.cs
│
├── Data/
│     └── AppDbContext.cs
│
├── Migrations/
│
└── Program.cs
🛠 Tech Stack

ASP.NET Core Web API

Entity Framework Core

SQL Server

Fluent API

Swagger

⚙️ Fluent API Configuration

Relationships are configured using Fluent API inside OnModelCreating():

modelBuilder.Entity<Student>()
    .HasOne(s => s.Mentor)
    .WithMany(m => m.Students)
    .HasForeignKey(s => s.MentorId)
    .OnDelete(DeleteBehavior.Cascade);
Why Fluent API?

Full control over relationship behavior

Explicit foreign key configuration

Configurable cascade rules

Clean and scalable architecture

Better suited for enterprise applications

🔎 Features

Create, update, delete mentors

Assign students to mentors

Retrieve mentor with associated students

Retrieve student with mentor details

Cascade delete (removing mentor removes students)

Proper indexing on foreign keys

Migration-based database generation

📦 API Endpoints
Mentor Endpoints
Method	Endpoint	Description
GET	/api/mentor	Get all mentors
GET	/api/mentor/{id}	Get mentor with students
POST	/api/mentor	Create mentor
PUT	/api/mentor/{id}	Update mentor
DELETE	/api/mentor/{id}	Delete mentor
Student Endpoints
Method	Endpoint	Description
GET	/api/student	Get all students
GET	/api/student/{id}	Get student with mentor
POST	/api/student	Create student
PUT	/api/student/{id}	Update student
DELETE	/api/student/{id}	Delete student
🗄 Database Schema
Mentors Table
Column	Type
Id	int (PK)
MentorName	nvarchar(100)
Email	nvarchar
Students Table
Column	Type
Id	int (PK)
StudentName	nvarchar(100)
MentorId	int (FK)
🔄 Migration Commands
Add-Migration InitialCreate
Update-Database
🧠 Key Learning Outcomes

Understanding navigation properties in EF Core

Configuring One-to-Many relationships using Fluent API

Controlling cascade delete behavior

Implementing eager loading using Include()

Designing clean and maintainable API structure

Managing migrations and database synchronization

📈 Future Enhancements

DTO implementation to avoid circular references

Repository & Service layer abstraction

Pagination & filtering support

Authentication & authorization

Many-to-Many mentor-student extension

Clean Architecture implementation

📌 Author

Developed as a practice project to deepen understanding of Entity Framework Core relationships and Fluent API configuration, with a focus on writing scalable and production-ready backend systems.
