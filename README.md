# College Portal System

![TA Home Page](path-to-your-image/ta-home-page.png)

## Overview

The **College Portal System** is a comprehensive solution for managing academic and administrative processes within a college or university. Built using the ASP.NET Core MVC framework and leveraging Microsoft SQL Server for database management, the system offers a centralized platform for students, professors, teaching assistants (TAs), and administrators to perform their roles effectively.

## Features

### General
- Role-based access control for students, TAs, professors, and administrators.
- Centralized management of academic tasks and communications.
- Scalable architecture for future growth and integration.

### Students
- Course registration and transcript access.
- Task submissions, quiz participation, and grade viewing.
- Profile management for personal details.

### Teaching Assistants
- Task creation and assignment.
- Review and grading of student submissions.
- Analysis of quiz and task results.

### Professors
- Course and exam management.
- Educational material uploads and feedback provision.
- Analytical views of student performance.

### Administrators
- User management for students, professors, and TAs.
- Course and department oversight.
- Academic performance analysis and report generation.

## Technologies Used
- **Frontend**: HTML5, CSS3, Bootstrap, JavaScript, jQuery, Ajax.
- **Backend**: ASP.NET Core MVC, C#.
- **Database**: Microsoft SQL Server.
- **Hosting**: Microsoft Azure.
- **Version Control**: Git and GitHub.

## System Architecture
The application is built using a 3-tier architecture:
1. **Presentation Layer**: User interface for interaction.
2. **Business Logic Layer**: Processes user requests and applies business rules.
3. **Data Access Layer**: Handles data storage and retrieval.

## Database Design
- A relational database with tables for users, courses, tasks, submissions, and notifications.
- Entity Framework Core for object-relational mapping (ORM).
- Disjoint relations for role differentiation.

## Setup and Deployment
1. Clone the repository:  
   ```bash
   git clone https://github.com/Hazem-Ahmed1/College-Portal-System-DEPI-GP.git
   ```
2. Configure the database connection in `appsettings.json`.
3. Run database migrations using Entity Framework Core.
4. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```
5. Access the application at `http://localhost:5000`.

## Screenshots
### TA Home Page
![TA Home Page](path-to-your-image/ta-home-page.png)


