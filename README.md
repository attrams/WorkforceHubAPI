# WorkforceHub API
A RESTful API for managing employees, companies, and related data in a corporate environment. This API supports CRUD operations for managing companies and employees, along with logging and database access features.

## Table of Contents

- [WorkforceHub API](#workforcehub-api)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Features](#features)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
  - [Technologies](#technologies)

## Introduction

WorkforceHub API allows users to manage data related to employees and companies. It uses **ASP.NET Core**, **Entity Framework Core**, and a well-structured **onion architecture** to ensure maintainable and scalable code. The API includes logging capabilities, database seeding for initial data, and dependency injection for flexibility.

## Features

- Logging implemented using Serilog.
- Data persistence with SQL Server.
- Migration-based database management.
- Mock data pre-seeded for development.

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
- Docker
