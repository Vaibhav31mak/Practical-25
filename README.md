# Practical25

## Overview

Practical25 is an enterprise-style ASP.NET Core Web API built with .NET 10 implementing:

- Clean Architecture
- CQRS Pattern
- MediatR
- FluentValidation
- Entity Framework Core
- AutoMapper
- SQL Server

The solution demonstrates separation of concerns using:
- Commands and Queries
- Request Handlers
- Validation Pipeline Behaviors
- Layered architecture

The application manages Employee CRUD operations through MediatR handlers instead of directly coupling controllers to services or repositories.

---

# Architecture

The solution follows Clean Architecture with four layers:

```text
Practical25.Api
    ↓
Practical25.Application
    ↓
Practical25.Infrastructure
    ↓
Practical25.Domain
```

## Layer Responsibilities

| Layer | Responsibility |
|---|---|
| Api | Controllers, DI configuration, middleware |
| Application | CQRS, MediatR handlers, validators, DTOs |
| Infrastructure | EF Core, repositories, database access |
| Domain | Entities and enums |

---

# Tech Stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- AutoMapper
- Swagger/OpenAPI

---

# Project Structure

```text
Practical25.Api
│
├── Controllers
├── Middleware
├── Program.cs
└── appsettings.json

Practical25.Application
│
├── Behaviours
├── Features
│   └── Employees
│       ├── Commands
│       ├── Queries
│       ├── Handlers
│       ├── Validators
│       ├── DTOs
│       └── Responses
│
└── Mappings

Practical25.Infrastructure
│
├── Context
├── Migrations
├── Repositories
└── UnitOfWork

Practical25.Domain
│
├── Entities
└── Enums
```

---

# CQRS + MediatR Request Flow

The application uses MediatR pipeline behaviors for validation and request handling.

```text
Controller
    ↓
MediatR
    ↓
ValidationBehaviour
    ↓
FluentValidation
    ↓
Handler
    ↓
EF Core
    ↓
SQL Server
```

## Flow Explanation

1. Controller sends request using `IMediator`
2. MediatR locates the correct handler
3. ValidationBehaviour executes FluentValidation validators
4. If validation passes, the handler executes
5. Handler performs EF Core database operations
6. Response is returned to controller

---

# Dependency Injection Setup

The application registers services in `Program.cs`:

## Registered Services

- DbContext
- MediatR handlers
- FluentValidation validators
- Validation pipeline behavior
- Repositories
- Unit Of Work
- AutoMapper

## Key Registrations

```csharp
builder.Services.AddMediatR(...);

builder.Services.AddValidatorsFromAssembly(...);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehaviour<,>));

builder.Services.AddDbContext<ApplicationDbContext>(...);
```

---

# Employee Entity

| Property | Type |
|---|---|
| Id | int |
| Name | string |
| Salary | decimal(18,2) |
| DepartmentId | int |
| EmailId | string |
| JoiningDate | datetime |
| Status | bit |

---

# Running The Project

## Prerequisites

Install:
- .NET 10 SDK
- SQL Server
- Visual Studio 2022 / VS Code

---

# Configure Connection String

Update `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=Practical25Db;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

# Run EF Core Migrations

## Create Migration

```bash
Add-Migration InitialCreate -Project Practical25.Infrastructure -StartupProject Practical25.Api
```

## Apply Migration

```bash
Update-Database -Project Practical25.Infrastructure -StartupProject Practical25.Api
```

---

# Run API

```bash
dotnet run --project Practical25.Api
```

Swagger UI:

```text
https://localhost:{port}/swagger
```

---

# EmployeesController Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | /api/employees | Create employee |
| GET | /api/employees | Get all employees |
| GET | /api/employees/{id} | Get employee by id |
| PUT | /api/employees | Update employee |
| DELETE | /api/employees/{id} | Delete employee |

---

# Sample Requests

## Create Employee

### Request

```json
{
  "name": "Vaibhav",
  "salary": 50000,
  "departmentId": 1,
  "emailId": "vaibhav@gmail.com"
}
```

### Response

```json
1
```

---

# Get Employee By Id

### Response

```json
{
  "id": 1,
  "name": "Vaibhav",
  "salary": 50000,
  "departmentId": 1,
  "emailId": "vaibhav@gmail.com",
  "joiningDate": "2026-05-27T10:00:00Z",
  "status": true
}
```

---

# Validation

FluentValidation is integrated through MediatR pipeline behaviors.

Examples:
- Name required
- Salary must be greater than 0
- Email format validation
- Department range validation

Validation executes automatically before handlers run.

---

# Code Quality

The project follows:
- SOLID principles
- Clean Architecture
- CQRS pattern
- Separation of concerns
- Async/await best practices

Additionally:
- Handlers contain focused business logic
- Validators are separated from handlers
- Methods include XML documentation summaries
- Pipeline behaviors centralize cross-cutting concerns

---

# Features

- Employee CRUD operations
- CQRS with MediatR
- FluentValidation pipeline
- EF Core integration
- SQL Server support
- AutoMapper mapping profiles
- Swagger documentation
- Clean layered architecture
- Dependency Injection
- Global validation handling

---

# Learning Objectives

This project demonstrates:
- Mediator Pattern
- CQRS Pattern
- MediatR request pipeline
- FluentValidation integration
- EF Core architecture
- Clean Architecture principles
- Enterprise API structuring
