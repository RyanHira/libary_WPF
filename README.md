# Bieb Application

The Bieb Application is a WPF (Windows Presentation Foundation) desktop application that allows users to manage a collection of books and their authors. It provides features such as adding, editing, and deleting books and authors, as well as viewing and searching the collection.

## Features
- Bekijk lijst van boeken en Authors
- Voeg een nieuwe boek met author toe
- Edit het boek
- Verwijder een boek
- Bekijk een lijst van Authors
- Voeg een author toe
- Edit de authors
- verwijder een author
- Zoek functie

## Technologies Used

- C# Programmer taal 
- WPF (Windows Presentation Foundation) for the desktop application framework
- Entity Framework Core for data access and ORM (Object-Relational Mapping)
- Microsoft SQL Server for the database
- MVVM (Model-View-ViewModel) architectural pattern for separation of concerns
- CommunityToolkit.Mvvm package for MVVM infrastructure
- RelayCommand and DelegateCommand for handling user commands
- Microsoft.EntityFrameworkCore package for Entity Framework Core integration

## Getting Started

### Prerequisites

- Visual Studio 2022 or later
- Microsoft SQL Server

### Installation

1. Clone the repository: `https://github.com/RyanHira/libary_WPF.git`
2. Open the solution file (`bieb-application.sln`) in Visual Studio.
3. Set up the database connection string in the `BiebDbContext` class, located in the `Models` folder.
4. Build the solution to restore NuGet packages.
5. Run the application from Visual Studio.
