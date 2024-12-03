# WorkforceHub API
A RESTful API for managing employees, companies, and related data. This API supports CRUD operations for managing companies and employees, along with logging and database access features.

## Table of Contents

- [WorkforceHub API](#workforcehub-api)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Project Structure](#project-structure)
    - [1. **WorkforceHubAPI.Contracts**](#1-workforcehubapicontracts)
    - [2. **WorkforceHubAPI.Entities**](#2-workforcehubapientities)
    - [3. **WorkforceHubAPI.LoggerService**](#3-workforcehubapiloggerservice)
    - [4. **WorkforceHubAPI.Repository**](#4-workforcehubapirepository)
    - [5. **WorkforceHubAPI.Service**](#5-workforcehubapiservice)
    - [6. **WorkforceHubAPI.Service.Contracts**](#6-workforcehubapiservicecontracts)
    - [7. **WorkforceHubAPI.Shared**](#7-workforcehubapishared)
    - [8. **WorkforceHubAPI.WebAPI**](#8-workforcehubapiwebapi)
    - [9. **WorkforceHubAPI.WebAPI.Presentation**](#9-workforcehubapiwebapipresentation)
  - [Features](#features)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
  - [Technologies](#technologies)

## Introduction

WorkforceHub API allows users to manage data related to employees and companies. It uses **ASP.NET Core**, **Entity Framework Core**, and a well-structured **onion architecture** to ensure maintainable and scalable code. The API includes logging capabilities, database seeding for initial data, and dependency injection for flexibility.

## Project Structure

The project is organized into several class libraries, each with its own 
responsibility. Below is a breakdown of each project in the solution:

### 1. **WorkforceHubAPI.Contracts**
  - **Purpose**: Contains all the interfaces for the application.
  - **Responsibilities**: Defines interfaces for the repositories, and other essential components that will be implemented in the other projects.

### 2. **WorkforceHubAPI.Entities**
  - **Purpose**: Contains the entity models for the application.
  - **Responsibilities**: Defines the core data structures such as `Company` and `Employee` which represent the main entities in the database.

### 3. **WorkforceHubAPI.LoggerService**
  - **Purpose**: Provides logging services for the application.
  - **Responsibilities**: Contains logic for logging system events and errors, making it easier to debug and monitor the application.

### 4. **WorkforceHubAPI.Repository**
  - **Purpose**: Handles data access and repository operations.
  - **Responsibilities**: Implements the repository pattern, providing methods for interacting with the database (e.g., `Create`, `Read`, `Update`, `Delete`). It uses Entity Framework Core to interact with the SQL database.

### 5. **WorkforceHubAPI.Service**
  - **Purpose**: Implements the business logic for the system.
  - **Responsibilities**: Implements the business logic services defined in `WorkforceHubAPI.Service.Contracts`, handling the core logic of the application like adding, updating, and processing company and employee data.

### 6. **WorkforceHubAPI.Service.Contracts**
  - **Purpose**: Contains interfaces for business logic services.
  - **Responsibilities**: Defines service interfaces for handling business logic related to entities like `Company` and `Employee`.

### 7. **WorkforceHubAPI.Shared**
  - **Purpose**: Contains shared resources that are used across multiple projects within the application.
  - **Responsibilities**: Defines shared resources such as **DTOs (Data Transfer Objects)** for communication between different layers of the application (e.g., `CompanyDto`, `EmployeeDto`).

### 8. **WorkforceHubAPI.WebAPI**
  - **Purpose**: Contains the entry point of the application and configuration.
  - **Responsibilities**: Contains the `Program.cs` file where the application is configured and started. This project serves as the API host, wiring up services and dependencies from the other projects, setting up the DI container, and configuring middleware.


### 9. **WorkforceHubAPI.WebAPI.Presentation**
  - **Purpose**: Contains the controllers for the API.
  - **Responsibilities**: Holds the API controllers responsible for handling HTTP requests and responding with the appropriate data. These controllers interact with services from `WorkforceHubAPI.Service` to process data.

## Features

- Logging implemented using Serilog.
- Data persistence with SQL Server.
- Migration-based database management.
- Mock data pre-seeded for development.
- Pagination and Filtering.

## Getting Started

Follow these steps to get the API up and running on your local machine.

### Prerequisites

- Docker (for running the app in containers)
- Docker Compose (optional, for multi-container setups)

## Technologies

- ASP.NET Core
- Entity Framework Core (EF Core)
- SQL Server
- Serilog for logging
- AutoMapper for mapping DTOs
- Docker
