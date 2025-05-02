# FlowerInventoryAPI

## Overview
FlowerInventoryAPI is a full-stack web application that allows users to manage a flower inventory. The application provides functionalities to perform CRUD (Create, Read, Update, Delete) operations on flower categories and flowers. 

The project is built with:
- **Backend:** .NET 9, Entity Framework Core
- **Frontend:** Angular v19
- **Database:** Local (SQL Server or PostgreSQL)

## Table of Contents
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup Instructions](#setup-instructions)
  - [Backend Setup](#backend-setup)
  - [Frontend Setup](#frontend-setup)
- [Running Unit Tests](#running-unit-tests)
- [Challenges Faced](#challenges-faced)
- [Assumptions Made](#assumptions-made)
- [Future Improvements](#future-improvements)

## Features
- **Manage Flower Categories**: Create, update, delete, and view flower categories.
- **Manage Flowers**: Create, update, delete, and view flowers.
- **User Authentication and Authorization**: (Planned for future versions)
- **Unit Tests**: Unit tests are written to ensure the functionality of the backend services.

## Technologies Used
- **Backend:**
  - .NET 9
  - Entity Framework Core
  - MSTest for Unit Testing
- **Frontend:**
  - Angular v19
- **Database:**
  - Local database (SQL Server or PostgreSQL)
- **Others:**
  - AutoFixture (for test data generation)
  - Moq (for mocking dependencies in unit tests)

## Setup Instructions

### Backend Setup
Follow these steps to set up the backend:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/TheodoulosChristou/FlowerInventoryBackend.git
   cd FlowerInventoryAPI

2. **Restore dependencies**:
Make sure you are in the FlowerInventoryAPI directory, then run:
  ```bash
  dotnet restore

4. **Set up your local database**:
  Ensure that your local database (SQL Server or PostgreSQL) is running.
  Update the connection string in appsettings.json to match your local database configuration.

5. **Run the database migrations**:
  Apply all pending migrations and update the database schema
  ```bash
  dotnet ef database update

6. **Run the backend**:
  Start the backend application:
  ```bash
  dotnet run
  The backend will be available at https://localhost:7163.

### Frontend Setup
Follow these steps to set up the frontend:

1. **Clone the repository (if you haven't already)**:
    ```bash
    git clone https://github.com/your-username/FlowerInventoryAPI.git
    cd flower-inventory

2. **Install dependencies**:
  Make sure you are in the flower-inventory directory, then run:
  ```bash
  npm install

3. **Run the frontend**:
   Start the Angular application:
   ```bash
   ng serve

   The frontend will be available at http://localhost:4200.

### Running Unit Tests (Backend)
1. **Navigate to the backend project directory**:
    ```bash
    cd FlowerInventoryTestAPI
2. **Run unit tests**:
    To execute all unit tests in the project, use:
    ```bash
    dotnet test

    This will run the tests using MSTest.

### Challenges Faced
Database Configuration: Configuring the local database correctly was challenging due to environment-specific settings, especially when setting up Entity Framework migrations.

CORS Issues: The frontend and backend were hosted on different ports during development (4200 for Angular, 7163 for .NET). This caused Cross-Origin Resource Sharing (CORS) issues, which were resolved by configuring CORS middleware in the backend.

Unit Testing: Mocking database interactions for unit tests required the use of Moq and AutoFixture to ensure tests were isolated and not dependent on a live database.

### Assumptions Made
Database: The application assumes that a local SQL Server instance is set up and accessible. The connection string should be updated accordingly in appsettings.json.

Ports: The backend is assumed to run on port 7163, and the frontend on 4200. If different ports are used, ensure CORS settings are adjusted.

Authentication: User authentication and authorization features are not implemented yet and are planned for future versions.

### Future Improvements
Authentication/Authorization: Implement user authentication (JWT or OAuth) to secure the API endpoints.

Deployment: Deploy the backend to a cloud platform (e.g., Azure, AWS) and the frontend to a static hosting platform (e.g., Netlify or Vercel).

UI Enhancements: Improve the user interface of the frontend to provide a better user experience, including forms, validation, and styling.

Error Handling: Add more robust error handling on both frontend and backend.

Testing: Expand unit and integration tests to cover more use cases.



