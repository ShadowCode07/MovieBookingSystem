# Movie Booking System

## Overview
Movie Booking System is a web-based application that allows users to browse available movies, book tickets, and manage their reservations. This system follows a microservices architecture, primarily developed in **C#** using **.NET Core**.

## Features
- Movie listing and details
- User authentication and profile management
- Ticket booking functionality
- Database integration using **Entity Framework**
- RESTful API architecture
- Docker support

## Technologies Used
- **C#** / .NET Core
- **Entity Framework Core** (EF Core) for database management
- **ASP.NET Core** for API development
- **Docker** for containerization
- **JSON-based configuration files** for settings management

## Installation & Setup
1. Clone the repository:
   ```sh
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```sh
   cd MovieBookingSystem
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Run the application:
   ```sh
   dotnet run --project MovieService/src/MovieSerive.API
   ```

## Authors
This project was developed by **Plamen Daylyanov** and **Kaloyan Dimov**.

