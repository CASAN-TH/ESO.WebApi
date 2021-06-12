# ESO.WebApi - Clean Architecture

Follow these steps to get started with this Boiler Plate Template.

### You can also clone the Repository.

1. Clone this Repository and Extract it to a Folder.
2. Change the Connection Strings for the Application and Identity in the WebApi/appsettings.json - (WebApi Project)
3. Run the following commands on Powershell in the WebApi Projecct's Directory.
- dotnet restore
- dotnet ef database update -Context ApplicationDbContext
- dotnet ef database update -Context IdentityContext
- dotnet run (OR) Run the Solution using Visual Studio 2019


### How to use MySQL or PostgreSQL as your Data Provider
The Project currently uses MSSQL as the default Data Provider. If you are more comfortable with MySQL or PostgreSQL, here is how to migrate to them easily.


1. delete all existing file inside migrations folder on both project
   - {YourProjectName}.Infrastructure.Identity
   - {YourProjectName}.Infrastructure.Persistence

2. In in `ServiceExtensions.cs` and `ServiceRegistration.cs` change from `options.UseSqlServer` to:
#### For MySql
`options.UseMySql`
#### For PostgreSQL
`options.UseNpgsql`

3. Add NuGet packages to both projects (Infrastructure.Identity and Infrastructure.Persistence):
#### For MySql:
run `dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.1.2` (remember to do this on both projects)
#### For PostgreSQL:
run 
```cli
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
```
(remember to do this on both projects)

4. on `IdentityContext.cs` comment `builder.HasDefaultSchema("Identity");` because ef doesn't support that on mysql

5. cd to `{YourProjectName}.Infrastructure.Identity` and run
   - `dotnet ef database update --startup-project ../{YourProjectName}.WebApi/{YourProjectName}.WebApi.csproj -c "IdentityContext"`
   - `dotnet ef migrations add Initial --startup-project ../{YourProjectName}.WebApi/{YourProjectName}.WebApi.csproj -c "IdentityContext"`

6. cd to `{YourProjectName}.Infrastructure.Persistence` and run
   - `dotnet ef database update --startup-project ../{YourProjectName}.WebApi/{YourProjectName}.WebApi.csproj -c "ApplicationDbContext"`
   - `dotnet ef migrations add Initial --startup-project ../{YourProjectName}.WebApi/{YourProjectName}.WebApi.csproj -c "ApplicationDbContext"`
   
The above guide (To use MySQL) was contributed by [geekz-reno](https://github.com/geekz-reno).

### Default Roles & Credentials
As soon you build and run your application, default users and roles get added to the database.

Default Roles are as follows.
- SuperAdmin
- Admin
- Moderator
- Basic

Here are the credentials for the default users.
- Email - superadmin@gmail.com  / Password - 123Pa$$word!
- Email - basic@gmail.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.

## Purpose of this Project

Does it really make sense to Setup your ASP.NET Core Solution everytime you start a new WebApi Project ? Aren't we wasting quite a lot of time in doing this over and over gain?

This is the exact Problem that I intend to solve with this Full-Fledged ASP.NET Core 3.1 WebApi Solution Template, that also follows various principles of Clean Architecture.

The primary goal is to create a Full-Fledged implementation, that is well documented along with the steps taken to build this Solution from Scratch. This Solution Template will also be available within Visual Studio 2019 (by installing the required Nuget Package / Extension).
- Demonstrate Clean Monolith Architecture in ASP.NET Core 3.1 
- This is not a Proof of Concept
- Implementation that is ready for Production
- Integrate the most essential libraries and packages

## Technologies
- ASP.NET Core 3.1 WebApi
- REST Standards
- .NET Core 3.1 / Standard 2.1 Libraries

## Features
- [x] Onion Architecture
- [x] CQRS with MediatR Library
- [x] Entity Framework Core - Code First
- [x] Repository Pattern - Generic
- [x] MediatR Pipeline Logging & Validation
- [x] Serilog
- [x] Swagger UI
- [x] Response Wrappers
- [x] Healthchecks
- [x] Pagination
- [ ] In-Memory Caching
- [ ] Redis Caching
- [x] In-Memory Database
- [x] Microsoft Identity with JWT Authentication
- [x] Role based Authorization
- [x] Identity Seeding
- [x] Database Seeding
- [x] Custom Exception Handling Middlewares
- [x] API Versioning
- [x] Fluent Validation
- [x] Automapper
- [x] SMTP / Mailkit / Sendgrid Email Service
- [x] Complete User Management Module (Register / Generate Token / Forgot Password / Confirmation Mail)
- [x] User Auditing

## Brief Overview
![alt text](https://www.codewithmukesh.com/wp-content/uploads/2020/06/Onion-Architecture-In-ASP.NET-Core.png)

## Prerequisites
- Visual Studio 2019 Community and above
- .NET Core 3.1 SDK and above
- Basic Understanding of Architectures and Clean Code Principles
- I Recommend that you read [Onion Architecture In ASP.NET Core With CQRS – Detailed](https://www.codewithmukesh.com/blog/onion-architecture-in-aspnet-core/) article to understand this implementation much better. This project is just an Advanced Version of the mentioned article.
