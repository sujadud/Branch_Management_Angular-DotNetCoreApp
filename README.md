# Branch Management System

This project is a comprehensive Branch Management System developed using **ASP.NET Core** for the backend and **Angular** for the frontend. It enables efficient management of company branches across various cities, along with employee assignments and roles.

## Table of Contents

-   [Features](#features)
-   [Technologies Used](#technologies-used)
-   [Getting Started](#getting-started)
    -   [Prerequisites](#prerequisites)
    -   [Installation](#installation)
-   [Usage](#usage)
-   [API Endpoints](#api-endpoints)
-   [Frontend Components](#frontend-components)
-   [Contributing](#contributing)
-   [License](#license)

## Features

-   **Branch Management**: Create, update, and list branches with associated cities.
-   **Employee Management**: Assign employees to branches with specific roles.
-   **Form Validation**: Robust validation mechanisms to ensure data integrity.
-   **Loading Indicators**: Enhanced user experience with responsive loading indicators.

## Technologies Used

-   **Backend**:
    
    -   ASP.NET Core
    -   Entity Framework Core
    -   CQRS & Mediator Pattern
-   **Frontend**:
    
    -   Angular
    -   Angular Material
    -   RxJS

## Getting Started

### Prerequisites

-   [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
-   [Node.js](https://nodejs.org/) (**18.10.0** LTS version recommended)
-   [Angular CLI]()
-   [SQL Server](https://www.microsoft.com/en-us/sql-server)

### Installation

1.  **Clone the repository**:    
    
    `git clone https://github.com/sujadud/Branch_Management_Angular-DotNetCoreApp.git` 
    
2.  **Navigate to the backend project directory**:    
    
    `cd Branch_Management_Angular-DotNetCoreApp/BM.Web` 
    
3.  **Apply database migrations**:
    
    `dotnet ef database update` 
    
4.  **Run the backend API**:
    
    `dotnet run` 
    
5.  **Navigate to the frontend project directory**:
    
    `cd ../BM.Web/ClientApp` 
    
6.  **Install frontend dependencies**:
    
    `npm install` 
    
7.  **Run the Angular application**:
    
    `ng serve` 
    

## Usage

-   Access the Angular application at `http://localhost:4200/`.
-   Use the navigation menu to manage branches, employees, cities, and roles.
-   Forms include validation to ensure proper data entry.

## API Endpoints

-   **Branches**:
    
    -   `GET /api/branches`
    -   `POST /api/branches`
    -   `PUT /api/branches/{id}`
    -   `DELETE /api/branches/{id}`
-   **Employees**:
    
    -   `GET /api/employees`
    -   `POST /api/employees`
    -   `PUT /api/employees/{id}`
    -   `DELETE /api/employees/{id}`
-   **Cities**:
    
    -   `GET /api/cities`
    -   `POST /api/cities`
    -   `PUT /api/cities/{id}`
    -   `DELETE /api/cities/{id}`
-   **Roles**:
    
    -   `GET /api/roles`
    -   `POST /api/roles`
    -   `PUT /api/roles/{id}`
    -   `DELETE /api/roles/{id}`

## Frontend Components

-   **Branch Components**:
    
    -   `branch-list`
    -   `branch-create`
    -   `branch-edit`
-   **Employee Components**:
    
    -   `employee-list`
    -   `employee-create`
    -   `employee-edit`
-   **Shared Components**:
    
    -   `pagination`
    -   `loading-spinner`
    -   `validation-messages`

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes. Happy Codding!

## License

This project is licensed under the MIT License. See the LICENSE file for details.
