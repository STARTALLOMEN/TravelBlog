# TravelBlog

## Overview

TravelBlog is a web application designed to share and explore travel experiences. The project is divided into two main parts: the backend API and the frontend ReactJS application.

## Project Structure


## Backend API

The backend API is built using ASP.NET Core and provides endpoints for managing travel blog data.

### Key Files and Directories

- **[API.csproj](Back_end/API/API.csproj)**: Project file for the API.
- **[API.sln](Back_end/API/API.sln)**: Solution file for the API.
- **[appsettings.json](Back_end/API/appsettings.json)**: Configuration file for the API.
- **[Program.cs](Back_end/API/Program.cs)**: Entry point for the API application.
- **[Controllers](Back_end/API/Controllers/)**: Contains API controllers.
- **[Data](Back_end/API/Data/)**: Contains the `DataContext` class for database interactions.
- **[Mapping](Back_end/API/Mapping/)**: Contains AutoMapper configuration.
- **[Migrations](Back_end/API/Migrations/)**: Contains EF Core migrations.
- **[Models](Back_end/API/Models/)**: Contains data models.
- **[Repositories](Back_end/API/Repositories/)**: Contains repository classes.
- **[Services](Back_end/API/Services/)**: Contains service classes.

### Key Classes

- **[`DataContext`](Back_end/API/Data/DataContext.cs)**: Database context class.
- **[`DataContextModelSnapshot`](Back_end/API/Migrations/DataContextModelSnapshot.cs)**: Snapshot of the database model.
- **[`AutoMappingConfiguration`](Back_end/API/Mapping/AutoMappingConfiguration.cs)**: AutoMapper configuration class.
- **[`UploadImgService`](Back_end/API/Services/UploadImgService.cs)**: Service class for handling image uploads.

### Running the API

To run the API, navigate to the `Back_end/API` directory and use the following command:

```sh
dotnet run

Frontend ReactJS Application
The frontend is built using ReactJS and provides a user interface for interacting with the TravelBlog API.

Running the Frontend
To run the frontend application, navigate to the Front_end/reactjs-app directory and use the following commands:

npm install
npm start