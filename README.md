# TechStore

TechStore is a modern, full-stack e-commerce application designed to provide a seamless shopping experience. It features a robust backend built with .NET 9 and a dynamic frontend powered by Angular 19.

## 🚀 Overview

The application allows users to browse products, manage their cart, place orders, and securely checkout. It includes a comprehensive administration panel for managing products, categories, and users.

## 🛠 Technologies

### Frontend
*   **Framework**: [Angular 19](https://angular.io/)
*   **Styling**: Bootstrap 5, SCSS
*   **State/Async**: RxJS
*   **Icons**: Lucide Angular

### Backend
*   **Framework**: [.NET 9 Web API](https://dotnet.microsoft.com/)
*   **Database**: SQL Server
*   **ORM**: Entity Framework Core
*   **Caching**: Redis
*   **Object Mapping**: AutoMapper
*   **Identity**: ASP.NET Core Identity
*   **Documentation**: Swagger / OpenAPI

## 🏁 Getting Started

Follow these instructions to get the project up and running on your local machine.

### Prerequisites
*   [Node.js](https://nodejs.org/) (Latest LTS)
*   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
*   [SQL Server](https://www.microsoft.com/sql-server)
*   [Redis](https://redis.io/) (Optional, ensures caching works)

### Installation

#### 1. Clone the repository
```bash
git clone https://github.com/1AhmedMagdy1/TechStore.git
cd TechStore
```

#### 2. Backend Setup
Navigate to the API directory and restore dependencies.
```bash
cd BackEnd
dotnet restore
```
Update the connection strings in `appsettings.json` (if necessary) to point to your local SQL Server and Redis instances.

Apply database migrations:
```bash
cd Api
dotnet ef database update
```
*Note: Ensure you have the `dotnet-ef` tool installed globally.*

Run the API:
```bash
dotnet run
```
The API will be available at `https://localhost:7197` (or similar, check console output).

#### 3. Frontend Setup
Navigate to the frontend directory.
```bash
cd ../../FrontEnd
npm install
```

Run the development server:
```bash
ng serve
```
Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## ✨ Features

*   **User Authentication**: Secure login and registration.
*   **Product Catalog**: Browse and search for products with pagination and filtering.
*   **Shopping Cart**: Add, remove, and update items in the cart (Redis-backed).
*   **Checkout Flow**: Address selection, delivery methods, and order summary.
*   **Error Handling**: Centralized exception handling and standardized API responses.

## 📚 API Documentation

Once the backend is running, you can explore the API endpoints via Swagger UI:
*   URL: `https://localhost:7197/swagger/index.html` (Adjust port as needed)


