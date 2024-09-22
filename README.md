# TestTask

### Steps (Without Docker)
1. **Clone the repository:**
   ```bash
   git clone https://github.com/Velovo123/TestTask.git
   cd TestTask
2. **Install Dependencies: Restore the .NET dependencies for the project:**
   ```bash
   dotnet restore
3. **Set up SQL Server: Ensure that SQL Server is installed and running on your machine. If you don't have it, you can install it [here](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads)**

4. **Configure Connection String: Open the appsettings.json file in the root of the project and update the connection string to match your local SQL Server setup. Example:**
    ```bash
   "Server=localhost;Database=TestTaskDb;User Id=sa; Password=your_password;"
5. **Apply Database Migrations:**
    ```bash
    dotnet ef database update
6. **Run the Application:**
    ```bash
    dotnet run


### Steps (With Docker)
1. **Clone the repository:**
   ```bash
   git clone https://github.com/Velovo123/TestTask.git
   cd TestTask
2. **Ensure Docker and Docker Compose are Installed**
3. **Build and Run the Docker Containers:**
   ```bash
   docker-compose up
